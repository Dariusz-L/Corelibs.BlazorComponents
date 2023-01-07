using BlazorComponentsLayersTest.Extensions;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentsLayersTest.Layouts
{
    public abstract class BaseLayout : ComponentBase
    {
        protected string Style 
        { 
            get 
            {
                var type = GetType();
                var properties = type.GetProperties().ToArray();
                var cssAttProperties = properties.Where(p => p.PropertyType == typeof(CssAttribute)).ToArray();
                var cssAttValues = cssAttProperties
                    .Select(p => new { property = p, value = p.GetValue(this) as CssAttribute })
                    .Where(p => p.value != null)
                    .ToArray();

                var styles = cssAttValues.Select(kv =>
                {
                    var name = kv.property.Name.PascalToKebabCase();
                    var value = kv.value.ToString();

                    return $"{name}: {value};";
                }).ToArray();

                if (styles.Length <= 1)
                    return styles.FirstOrDefault();

                return styles.Aggregate((x, y) => x + y);
            }
        }
    }
}
