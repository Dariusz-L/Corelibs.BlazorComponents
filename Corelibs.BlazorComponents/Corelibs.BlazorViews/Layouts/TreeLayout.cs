using Corelibs.BlazorShared.UI.Css;
using Corelibs.BlazorShared.UI;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using Corelibs.BlazorViews.ViewModels;

namespace Corelibs.BlazorViews.Layouts
{
    public partial class TreeLayout
    {
        [Parameter] public TreeNode? Tree { get; set; }
        [Parameter] public Func<TreeNode, Task<bool>> BeforeExpand { get; set; }
        [Parameter] public Func<TreeNode, Task> AfterExpand { get; set; }

        [Parameter] public CssAttribute? Padding { get; set; }
        [Parameter] public CssAttribute? PaddingLeft { get; set; }

        [Parameter] public CssAttribute? OverflowX { get; set; }

        [Parameter] public double? LayoutGap { get; set; }
        [Parameter] public HighlightType Highlight { get; set; } = HighlightType.Outline;

        [Parameter] public Func<TreeNode, RenderFragment> GetContent { get; set; }

        [Parameter] public ModifyContentDelegate ModifyNode { get; set; }
        public delegate void ModifyContentDelegate(RenderTreeBuilder builder, TreeNode node, ref int sequence);

        int seq;
        int zIndex = 0;
        int curTreeNodeIndex;
        private RenderFragment GetTreeRenderFragment(TreeNode node)
        {
            if (node == null)
                return builder => { };

            var childrenFragments = new List<RenderFragment>();
            if (node.IsExpanded)
                childrenFragments = node.Children!.Select(GetTreeRenderFragment).ToList();

            return builder =>
            {
                builder.OpenComponent<VerticalLayout>(ref seq);

                //if (Highlight != HighlightType.None)
                builder.AddClassAttribute(ref seq, $"highlight-{curTreeNodeIndex++}");

                builder
                    .AddCssAttribute(ref seq, "ZIndex", zIndex)
                    .AddCssAttribute(ref seq, "Height", "fit-content")
                    .AddCssAttribute(ref seq, "Gap", 15);

                ModifyNode?.Invoke(builder, node, ref seq);

                builder.AddAttribute(ref seq, "ChildContent", new RenderFragment(
                        (RenderTreeBuilder childBuilder) =>
                        {
                            if (node.CanExpand)
                            {
                                if (node.HasChildren || node.Children.Count > 0)
                                {
                                    childBuilder.OpenElement(ref seq, "div");
                                    {
                                        childBuilder.AddClassAttribute(ref seq, "side-menu");
                                        childBuilder.OpenElement(ref seq, "button")
                                            .AddCssAttribute(ref seq, "class", "expand-button")
                                            .AddAttribute(ref seq, "onclick", () => SwitchExpand(node))
                                            .OpenElement(seq++, "img");
                                        {
                                            childBuilder.AddAttribute(seq++, "class", "expand-icon");
                                            childBuilder.AddAttribute(seq++, "src", node.IsExpanded ? "_content/Corelibs.BlazorViews/icons/chevron-down.png" : "_content/Corelibs.BlazorViews/icons/chevron-right.png");
                                        }
                                        childBuilder.CloseElement();
                                        childBuilder.CloseElement();
                                    }
                                    childBuilder.CloseElement();
                                }
                            }

                            if (node.GetContent != null)
                                childBuilder.AddContent(seq++, node.GetContent(node, ref seq));

                            if (childrenFragments.Count > 0)
                            {
                                childBuilder.OpenComponent(seq++, TreeLayoutExtensions.GetComponent(node.Layout.Type));
                                {
                                    //childBuilder.AddCssAttribute(ref seq, "MarginBottom", 15);
                                    if (LayoutGap.HasValue)
                                        childBuilder.AddAttribute(seq++, "Gap", new CssAttribute(LayoutGap.Value));
                                    else if (node.Layout != null)
                                        childBuilder.AddAttribute(seq++, "Gap", new CssAttribute(node.Layout.Gap));

                                    childBuilder.AddAttribute(seq++, "Background", null as CssAttribute);

                                    if (node.Layout.Type != LayoutType.Vertical)
                                        childBuilder.AddAttribute(seq++, "ChildWidth", new CssAttributeExt("fit-content"));

                                    RenderFragment childrenActualLayoutFragment = (RenderTreeBuilder b) =>
                                    {
                                        for (int i = 0; i < childrenFragments.Count; i++)
                                            b.AddContent(seq++, childrenFragments[i]);
                                    };

                                    childBuilder.AddAttribute(seq++, "ChildContent", childrenActualLayoutFragment);
                                }
                                childBuilder.CloseComponent();
                            }
                        }))
                    .CloseComponent();
            };
        }

        protected override void OnAfterRender(bool firstRender)
        {
            seq = 0;
            curTreeNodeIndex = 0;
        }

        private async Task SwitchExpand(TreeNode node)
        {
            if (BeforeExpand != null)
            {
                var result = await BeforeExpand.Invoke(node);
                if (!result)
                    return;
            }

            node.IsExpanded = !node.IsExpanded;
            await InvokeAsync(StateHasChanged);

            await AfterExpand.Invoke(node);
        }

        int treeNodeCount;
        private RenderFragment GetParentStyle()
        {
            return b =>
            {
                b.OpenElement(seq++, "style");
                {
                    var count = treeNodeCount + 1;
                    for (int i = 0; i < count; i++)
                    {
                        var notString = "";

                        for (int j = i + 1; i < count; j++)
                        {
                            if (j >= count)
                                break;
                            notString += $":not(:has(.highlight-{j}:hover))";
                        }

                        if (i != 0)
                        {
                            // highlight-hover
                            b.AddContent(seq++, ".highlight-" + i + ":hover" + notString + "{");
                            //b.AddContent(seq++, "background: #f1f1f1 !important;");
                            //b.AddContent(seq++, "opacity: 70% !important;");

                            if (Highlight == HighlightType.Outline)
                                b.AddContent(seq++, "outline: solid 1px;");
                            else
                            if (Highlight == HighlightType.Color)
                                b.AddContent(seq++, "background: grey;");
                            else
                            if (Highlight == HighlightType.Opacity)
                                ;

                            b.AddContent(seq++, "}");

                            // highlight
                            b.AddContent(seq++, ".highlight-" + i + "{");
                            //b.AddContent(seq++, "box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);");
                            b.AddContent(seq++, "}");
                        }

                        b.AddContent(seq++, ".highlight-" + i + ":hover" + notString + "> .side-menu {");
                        b.AddContent(seq++, "display: flex;");
                        b.AddContent(seq++, "}");
                    }
                }
                b.CloseElement();
            };
        }

        public class TreeNode
        {
            public List<TreeNode>? _children { get; set; } = new();

            public IdentityVM Identity { get; set; } = new();
            public GetContentDelegate? GetContent { get; set; }
            public TreeNode? Parent { get; set; }
            public List<TreeNode>? Children {
                get => _children;
                set {
                    _children = value;
                    value.ForEach(n => n.Parent = this);
                }
            }

            public bool CanExpand { get; set; } = true;
            public bool IsExpanded { get; set; } = false;
            public bool HasChildren { get; set; }
            public Layout Layout { get; set; } = new();
            public object? Data { get; set; }

            public delegate RenderFragment GetContentDelegate(TreeNode node, ref int sequence);
        }

        public class Layout
        {
            public LayoutType Type { get; set; }
            public float Gap { get; set; }
        }

        public enum LayoutType
        {
            Vertical,
            Horizontal,
            Grid
        }

        public class Content<T>
        {
            public RenderFragment? Fragment { get; set; }
            public ReferenceCapture<T>? Reference { get; } = new();
        }

        public enum HighlightType
        {
            None,
            Outline,
            Opacity,
            Color
        }
    }
}
