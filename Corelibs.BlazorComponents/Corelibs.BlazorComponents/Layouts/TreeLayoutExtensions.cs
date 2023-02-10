using Corelibs.BlazorShared.UI;
using Microsoft.AspNetCore.Components;
using static Corelibs.BlazorComponents.Layouts.TreeLayout;

namespace Corelibs.BlazorComponents.Layouts
{
    public static class TreeLayoutExtensions
    {
        public static Content<T> CreateComponent<T>(params object[] arguments)
             where T : class, IComponent
        {
            var content = new Content<T>();

            content.Fragment = RenderFragmentExtensions.CreateComponent<T>(builder =>
            {
                builder.AddComponentReferenceCapture(0, obj =>
                {
                    content.Reference.Value = obj as T;
                });
            }, arguments);

            return content;
        }

        public static Type GetComponent(TreeLayout.LayoutType layoutType) =>
            layoutType switch
            {
                TreeLayout.LayoutType.Vertical => typeof(VerticalLayout),
                TreeLayout.LayoutType.Horizontal => typeof(VerticalLayout),
                TreeLayout.LayoutType.Grid => typeof(GridLayout),
                _ => typeof(VerticalLayout)
            };
    }
}
