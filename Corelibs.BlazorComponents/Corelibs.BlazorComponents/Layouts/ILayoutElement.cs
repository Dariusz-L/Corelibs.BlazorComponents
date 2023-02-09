using Corelibs.BlazorShared.UI.Css;
using Microsoft.AspNetCore.Components;

namespace Corelibs.BlazorComponents.Layouts
{
    public interface ILayoutElement
    {
        RenderFragment? ChildContent { get; set; }

        CssAttribute? Width { get; set; }
        CssAttribute? MinWidth { get; set; }
        CssAttribute? MaxWidth { get; set; }

        CssAttribute? Height { get; set; }
        CssAttribute? MinHeight { get; set; }
        CssAttribute? MaxHeight { get; set; }

        CssAttribute? Padding { get; set; }
        CssAttribute? PaddingLeft { get; set; }
        CssAttribute? PaddingRight { get; set; }

        Task RefreshView();
    }
}
