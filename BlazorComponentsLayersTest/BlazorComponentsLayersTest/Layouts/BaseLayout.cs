using BlazorComponentsLayersTest.Extensions;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentsLayersTest.Layouts
{
    public abstract class BaseLayout : BaseElement
    {
        [Parameter] public CssAttribute? Background { get; set; }// = GetRandomColor();
        [Parameter] public CssAttribute? ZIndex { get; set; }

        [Parameter] public CssAttribute? Padding { get; set; }
        [Parameter] public CssAttribute? PaddingLeft { get; set; }
        [Parameter] public CssAttribute? PaddingRight { get; set; }

        [Parameter] public CssAttribute? Gap { get; set; }

        [Parameter] public CssAttribute? Overflow { get; set; }
        [Parameter] public CssAttribute? OverflowX { get; set; }
        [Parameter] public CssAttribute? OverflowY { get; set; }

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
    }
}
