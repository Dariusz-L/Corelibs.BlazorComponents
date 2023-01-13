using BlazorComponentsLayersTest.Extensions;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentsLayersTest.Layouts
{
    public abstract class BaseLayout : ComponentBase
    {
        [Parameter] public string style { get; set; } = "";
        [Parameter] public string @class { get; set; } = "";

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
                    if (string.IsNullOrEmpty(value))
                        return "";

                    return $"{name}: {value};";
                }).ToArray();

                if (styles.Length <= 1)
                    return styles.FirstOrDefault();

                return styles.Aggregate((x, y) => x + y);
            }
        }

        protected string CombinedStyle => Style + style;
    }

    public class LayoutElementsContainer : ILayoutElementsContainerAdd
    {
        public List<ILayoutElement> Elements { get; } = new();

        void ILayoutElementsContainerAdd.Add(ILayoutElement element) 
        {
            Elements.Add(element);
        }

        public double Height {
            get {
                if (Elements.Count <= 1)
                {
                    var heightAtt = Elements.FirstOrDefault()?.Height;
                    if (heightAtt != null)
                        return heightAtt.Value.Value;

                    return 0;
                }

                return Elements.Select(e => e.Height).Where(e => e != null).Select(e => e.Value.Value).Aggregate((x, y) => x + y);
            }
        }
    }

    public interface ILayoutElementsContainerAdd
    {
        void Add(ILayoutElement element);
    }
}
