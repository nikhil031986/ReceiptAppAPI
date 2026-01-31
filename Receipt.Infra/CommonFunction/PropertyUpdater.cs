using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

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
        internal async static Task<string> GeneratePassword(int length)
        {
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            string allChars = upperCase + digits;

            Random random = new Random();

            // Ensure at least one uppercase letter
            char firstChar = upperCase[random.Next(upperCase.Length)];
            // Ensure at least one digit
            char secondChar = digits[random.Next(digits.Length)];

            // Fill the rest of the password
            char[] password = new char[length];
            password[0] = firstChar;
            password[1] = secondChar;

            for (int i = 2; i < length; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Shuffle the password to avoid predictable positions
            return new string(password.OrderBy(_ => random.Next()).ToArray());
        }
    }
}
