using BlazorComponentsLayersTest.Extensions;
using Microsoft.AspNetCore.Components;
using static BlazorComponentsLayersTest.Layouts.TreeLayout;

namespace BlazorComponentsLayersTest.Layouts
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
    }
}
