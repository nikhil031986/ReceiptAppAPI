using System.Reflection;

namespace Receipt.Infra.CommonFunction
{
    internal static class PropertyUpdater
    {
        internal async static void UpdateMatchingProperty<T>(T target, T source)
        {
            if (target == null || source == null)
                throw new ArgumentNullException("Source and target cannot be null.");
            // Get all public instance properties
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                // Only update if property is writable and readable
                if(prop.Name.ToLower().Contains("createuserid") ||
                    prop.Name.ToLower().Contains("createdat"))
                {
                    continue;
                }
                if (prop.CanWrite && prop.CanRead)
                {
                    object value = prop.GetValue(source);
                    prop.SetValue(target, value);
                }
            }
        }
    }
}
