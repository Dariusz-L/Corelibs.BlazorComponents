using Common.Basic.Functional;
using Corelibs.BlazorShared.UI;
using Corelibs.BlazorShared.UI.Css;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;

namespace Corelibs.BlazorViews.Layouts
{
    public abstract class BaseLayout : BaseElement, ILayoutElement
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }

        [Parameter] public CssAttribute? Background { get; set; } //= GetRandomColor();
        [Parameter] public CssAttribute? ZIndex { get; set; }

        [Parameter] public CssAttribute? Padding { get; set; }
        [Parameter] public CssAttribute? PaddingLeft { get; set; }
        [Parameter] public CssAttribute? PaddingRight { get; set; }

        [Parameter] public CssAttribute? Margin { get; set; }
        [Parameter] public CssAttribute? MarginLeft { get; set; }
        [Parameter] public CssAttribute? MarginRight { get; set; }
        [Parameter] public CssAttribute? MarginTop{ get; set; }
        [Parameter] public CssAttribute? MarginBottom { get; set; }

        [Parameter] public CssAttribute? Gap { get; set; }

        [Parameter] public CssAttribute? Overflow { get; set; }
        [Parameter] public CssAttribute? OverflowX { get; set; }
        [Parameter] public CssAttribute? OverflowY { get; set; }

        [Parameter] public CssAttribute? BorderRadius { get; set; }

        [Parameter] public CssAttributeExt ChildWidth { get; set; }
        [Parameter] public CssAttributeExt ChildMinWidth { get; set; }
        [Parameter] public CssAttributeExt ChildMaxWidth { get; set; }

        [Parameter] public CssAttributeExt ChildHeigth { get; set; }
        [Parameter] public CssAttributeExt ChildMinHeigth { get; set; }
        [Parameter] public CssAttributeExt ChildMaxHeigth { get; set; }

        // Layout Element
        [CascadingParameter] public ILayoutElementsContainerAdd Container { get; set; }

        [Parameter] public CssAttribute? Width { get; set; }
        [Parameter] public CssAttribute? MinWidth { get; set; }
        [Parameter] public CssAttribute? MaxWidth { get; set; }

        [Parameter] public CssAttribute? Height { get; set; }
        [Parameter] public CssAttribute? MinHeight { get; set; }
        [Parameter] public CssAttribute? MaxHeight { get; set; }

        [Parameter] public Func<Task>? OnClick { get; set; }

        [Inject] private IJSRuntime _jsRuntime { get; set; }

        protected ElementReference _reference;

        public Task RefreshView() => InvokeAsync(StateHasChanged);

        protected override void OnInitialized()
        {
            Container?.Add(this);
        }

        protected LayoutElementsContainer _children { get; } = new LayoutElementsContainer();

        protected override void OnAfterRender(bool firstRender)
        {
            foreach (var child in _children.Elements)
            {
                if (!NullableExtensions.HasAnyValue(
                        ChildWidth, ChildMinWidth, ChildMaxWidth,
                        ChildHeigth, ChildMinHeigth, ChildMaxHeigth))
                    continue;

                child.Width = ChildWidth;
                child.MinWidth = ChildMinWidth;
                child.MaxWidth = ChildMaxWidth;

                child.Height = ChildHeigth;
                child.MinHeight = ChildMinHeigth;
                child.MaxHeight = ChildMaxHeigth;

                child.RefreshView();
            }
        }

        private static string GetRandomColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }

        private static string bgWithColor = $"background: {GetRandomColor()}";
        private static string bgNone = $"background: none";

        string color = GetRandomColor();

        protected async Task OnClickInternal(MouseEventArgs args)
        {
            if (args.Button != 0)
                return;

            var rect = await _jsRuntime.GetRect(_reference);
            if (args.PageX > rect.Left && args.PageX < rect.Right &&
                args.PageY > rect.Top && args.PageY < rect.Bottom)
            {
                if (OnClick != null && OnClick.GetInvocationList().Length > 0)
                    await OnClick();
            }
        }
    }
}
