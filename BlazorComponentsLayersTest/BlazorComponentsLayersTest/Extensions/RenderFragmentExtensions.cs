using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazorComponentsLayersTest.Extensions
{
    public static class RenderFragmentExtensions
    {
        public static RenderFragment CreateComponent<T>(params object[] arguments)
             where T : notnull, IComponent
        {
            var type = typeof(T);
            var parameterProperties = type.GetProperties().Where(p => p.GetCustomAttribute(typeof(ParameterAttribute)) != null).ToArray();

            return builder =>
            {
                builder.OpenComponent<T>(0);

                for (int i = 0; i < arguments.Length; i++) 
                    builder.AddAttribute(0, parameterProperties[i].Name, arguments[i]);

                builder.CloseComponent();
            };
        }
    }
}
