using System.ComponentModel;
using System.Reflection;
using d07_ex02.Attributes;

namespace d07_ex02.ConsoleSetter;

public class ConsoleSetter
{
    public static void SetValues<T>(T input) where T : class
    {
        Type type = typeof(T);
        Console.WriteLine($"Let's set {type.Name}!");

        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !Attribute.IsDefined(p, typeof(Attributes.NoDisplayAttribute))).ToArray();

        foreach (PropertyInfo property in properties)
        {
            string description = GetDescription(property);

            Console.Write($"Set {description}: ");
            string inputStr = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputStr))
            {
                object value = Convert.ChangeType(inputStr, property.PropertyType);
                property.SetValue(input, value);
            }
            else
            {
                object defaultValue = GetDefaultValue(property);
                property.SetValue(input, defaultValue);
            }
        }

        Console.WriteLine("\nWe've set our instance!");
        Console.WriteLine(input.ToString());
    }

    private static string GetDescription(PropertyInfo property)
    {
        DescriptionAttribute descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
        return descriptionAttribute != null ? descriptionAttribute.Description : property.Name;
    }

    private static object GetDefaultValue(PropertyInfo property)
    {
        DefaultValueAttribute defaultValueAttribute = property.GetCustomAttribute<DefaultValueAttribute>();
        if (defaultValueAttribute != null)
        {
            return defaultValueAttribute.Value;
        }
        else
        {
            Type propertyType = property.PropertyType;
            return propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
        }
    }
}