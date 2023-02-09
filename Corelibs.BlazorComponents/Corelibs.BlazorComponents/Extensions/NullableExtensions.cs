namespace Corelibs.BlazorComponents.Extensions
{
    public class NullableExtensions
    {
        public static bool HasAnyValue(params object?[] objects)
        {
            foreach (var @object in objects)
                if (@object != null)
                    return true;

            return false;
        }
    }
}
