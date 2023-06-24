// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;

Type type = typeof(DefaultHttpContext);

Console.WriteLine($"Type: {type.FullName}");
Console.WriteLine($"Assembly: {type.Assembly.FullName}");
Console.WriteLine($"Based on: {type.BaseType.FullName}");
Console.WriteLine();

Console.WriteLine("Fields:");
FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
foreach (FieldInfo field in fields)
{
    string fieldTypeName = field.FieldType.FullName;
    if (fieldTypeName.Contains("`"))
    {
        int backtickIndex = fieldTypeName.IndexOf('`');
        fieldTypeName = fieldTypeName.Substring(0, backtickIndex);
        Type[] genericArguments = field.FieldType.GetGenericArguments();
        string genericArgumentsList = string.Join(",", genericArguments.Select(arg => arg.FullName));
        fieldTypeName = $"{fieldTypeName}`{genericArguments.Length}[{genericArgumentsList}]";
    }
    Console.WriteLine($"{fieldTypeName} {field.Name}");
}
Console.WriteLine();

Console.WriteLine("Properties:");
PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
foreach (PropertyInfo property in properties)
{
    string propertyTypeName = property.PropertyType.FullName;
    if (property.PropertyType.IsGenericType && !property.PropertyType.IsGenericTypeDefinition)
    {
        Type[] genericArguments = property.PropertyType.GetGenericArguments();
        string[] genericArgumentTypeNames = genericArguments.Select(arg => arg.FullName).ToArray();
        string genericArgumentsList = string.Join(",", genericArgumentTypeNames);
        propertyTypeName = $"{property.PropertyType.GetGenericTypeDefinition().FullName}[{genericArgumentsList}]";
    }
    Console.WriteLine($"{propertyTypeName} {property.Name}");
}
Console.WriteLine();


Console.WriteLine("Methods:");
MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
foreach (MethodInfo method in methods)
{
    ParameterInfo[] parameters = method.GetParameters();
    string parameterList = string.Join(", ", parameters.Select(p =>
    {
        if (p.ParameterType.IsGenericType && !p.ParameterType.IsGenericTypeDefinition)
        {
            Type genericType = p.ParameterType.GetGenericTypeDefinition();
            return $"{genericType.Name} {p.Name}";
        }
        return $"{p.ParameterType.Name} {p.Name}";
    }));
    Console.WriteLine($"{method.ReturnType.Name} {method.Name} ({parameterList})");
}

