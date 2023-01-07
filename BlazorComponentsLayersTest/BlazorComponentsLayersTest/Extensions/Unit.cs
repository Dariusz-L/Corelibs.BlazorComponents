namespace BlazorComponentsLayersTest.Extensions
{
    public enum Unit
    {
        px,
        rem
    }

    public static class UnitExtensions
    {
        public static string GetName(this Unit unit) =>
            unit switch
            {
                Unit.px => "px",
                Unit.rem => "rem",
                _ => ""
            };
    }
}
