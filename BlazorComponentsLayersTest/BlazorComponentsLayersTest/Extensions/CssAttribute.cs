using System.Text.RegularExpressions;

namespace BlazorComponentsLayersTest.Extensions
{
    public class CssAttribute
    {
        public double Value { get; set; } = 0;
        public double? Value2 { get; set; }
        public Unit Unit { get; set; } = Unit.px;

        public override string ToString()
        {
            var value1 = $"{Value}{Unit.GetName()}";
            var value2 = Value2.HasValue ? $" {Value2}{Unit.GetName()}" : "";

            return value1 + value2 + ';';
        }

        public static implicit operator CssAttribute(double value) => new CssAttribute { Value = value };
        public static implicit operator CssAttribute((double value, double value2) t) => new CssAttribute { Value = t.value, Value2 = t.value2 };
        public static implicit operator CssAttribute((double value, Unit unit) t) => new CssAttribute() { Value = t.value, Unit = t.unit };
        public static implicit operator CssAttribute((double value, double value2, Unit unit) t) => new CssAttribute { Value = t.value, Value2 = t.value2, Unit = t.unit };

    }

    public static class StringExtensions
    {
        public static string PascalToKebabCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return Regex.Replace(
                value,
                "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z0-9])",
                "-$1",
                RegexOptions.Compiled)
                .Trim()
                .ToLower();
        }
    }
}
