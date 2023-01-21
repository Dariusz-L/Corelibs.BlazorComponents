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

        public static RenderFragment CreateComponent<T>(params RFArg[] arguments)
             where T : notnull, IComponent
        {
            var type = typeof(T);

            return builder =>
            {
                builder.OpenComponent<T>(0);

                for (int i = 0; i < arguments.Length; i++)
                    builder.AddAttribute(0, arguments[i].Name, arguments[i].Value);

                builder.CloseComponent();
            };
        }

        public static RenderFragment CreateComponent<T>(RFArg argument1, params object[] arguments)
             where T : notnull, IComponent
        {
            var type = typeof(T);
            var parameterProperties = type.GetProperties().Where(p => p.GetCustomAttribute(typeof(ParameterAttribute)) != null).ToArray();

            return builder =>
            {
                builder.OpenComponent<T>(0);

                for (int i = 0; i < arguments.Length; i++)
                    builder.AddAttribute(0, parameterProperties[i].Name, arguments[i]);

                builder.AddAttribute(0, argument1.Name, argument1.Value);

                builder.CloseComponent();
            };
        }
    }

    public class RFArg
    {
        public RFArg(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; } = "";
        public object Value { get; } = "";

        public static implicit operator RFArg((string name, object value) arg) => new RFArg(arg.name, arg.value);
    }
}
