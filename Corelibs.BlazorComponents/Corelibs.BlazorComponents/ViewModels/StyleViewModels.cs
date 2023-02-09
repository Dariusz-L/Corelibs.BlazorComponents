using Corelibs.BlazorComponents.Layouts;
using System.Drawing;

namespace Corelibs.BlazorComponents.ViewModels
{
    public class StyleVM
    {
        public bool Visible { get; set; }
        public DisplayType HoverDisplayType { get; set; }
        public DisplayType EditDisplayType { get; set; }

        public FontVM Font { get; set; }
        public ColorsVM BackgroundColor { get; set; } = new();
        public BordersVM Borders { get; } = new();
    }

    public class StylePropertyVM
    {
        public List<StyleArtifactVM> Artifacts { get; } = new();
        public bool Visible { get; set; }
        public object Layout { get; set; }
        public object LayoutOfChildren { get; set; }

        public List<StylePropertyVM> Children { get; } = new();
    }

    public class StyleArtifactVM
    {
        public StyleArtifactType Type { get; private set; }
        public string ChildIndex { get; private set; }
        public VisualInfoVM VisualInfo { get; private set; }
    }

    public class VisualInfoVM
    {
        public bool Visible { get; set; }
        public FontVM Font { get; set; } = new();
    }

    public class FontVM
    {
        public string FontID { get; init; }
        public float FontSize { get; init; } = 12;
        public string FontWeightType { get; init; }
    }

    public class BordersVM
    {
        public float Radius { get; set; } = 5;
        public LineVM Top { get; set; } = new();
        public LineVM Bottom { get; set; } = new();
        public LineVM Right { get; set; } = new();
        public LineVM Left { get; set; } = new();
    }

    public class LineVM
    {
        public LineType Type { get; set; }
        public ColorsVM Colors { get; } = new();
        public float Thickness { get; set; } = 1;
    }

    public class ColorsVM
    {
        public Color Default { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public Color Hover { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public Color Edit { get; set; } = Color.FromArgb(0, 0, 0, 0);
    }

    public enum StyleArtifactType
    {
        Name,
        Signature,
        Child,
    }

    public enum DisplayType
    {
        None,
        Border,
        Background,
        Shadow
    }

    public enum LineType
    {
        Solid,
        Dashed,
        Dotted
    }

    public enum LayoutType
    {
        Vertical,
        Horizontal,
        Grid
    }

    public static class LayoutTypeExtensions
    {
        public static Type GetComponent(LayoutType layoutType) =>
            layoutType switch
            {
                LayoutType.Vertical => typeof(VerticalLayout),
                LayoutType.Horizontal => typeof(VerticalLayout),
                LayoutType.Grid => typeof(GridLayout),
                _ => typeof(VerticalLayout)
            };
    }
}
