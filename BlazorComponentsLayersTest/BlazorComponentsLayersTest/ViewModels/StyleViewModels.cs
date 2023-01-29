using BlazorComponentsLayersTest.Layouts;
using System.Drawing;

namespace BlazorComponentsLayersTest.ViewModels
{
    public class StyleInfo
    {
        public bool Visible { get; set; }
        public DisplayType HoverDisplayType { get; set; }
        public DisplayType EditDisplayType { get; set; }

        public FontInfo Font { get; set; }
        public ColorsInfo BackgroundColor { get; set; } = new();
        public BordersInfo Borders { get; } = new();
    }

    public class FontInfo
    {
        public string FontID { get; init; }
        public float FontSize { get; init; } = 12;
        public string FontWeightType { get; init; }
    }

    public class BordersInfo
    {
        public float Radius { get; set; } = 5;
        public LineInfo Top { get; set; } = new();
        public LineInfo Bottom { get; set; } = new();
        public LineInfo Right { get; set; } = new();
        public LineInfo Left { get; set; } = new();
    }

    public class LineInfo
    {
        public LineType Type { get; set; }
        public ColorsInfo Colors { get; } = new();
        public float Thickness { get; set; } = 1;
    }

    public class ColorsInfo
    {
        public Color DefaultColor { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public Color HoverColor { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public Color EditColor { get; set; } = Color.FromArgb(0, 0, 0, 0);
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
