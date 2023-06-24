using System.Reflection;

namespace d07_ex03;

public class TypeFactory
{
    public static T CreateWithConstructor<T>() where T : class
    {
        Type type = typeof(T);
        ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
        if (constructor == null)
        {
            throw new InvalidOperationException($"there is no constructor without parameters");
        }

        return (T)constructor.Invoke(null);
    }

    public static T CreateWithActivator<T>() where T : class
    {
        return Activator.CreateInstance<T>();
    }
    
    public static T CreateWithParameters<T>(object[] parameters) where T : class
    {
        Type type = typeof(T);
        ConstructorInfo constructor = type.GetConstructor(parameters.Select(p => p.GetType()).ToArray());
        if (constructor == null)
        {
            throw new InvalidOperationException($"there is no constructor with parameters");
        }

        return (T)constructor.Invoke(parameters);
    }
}