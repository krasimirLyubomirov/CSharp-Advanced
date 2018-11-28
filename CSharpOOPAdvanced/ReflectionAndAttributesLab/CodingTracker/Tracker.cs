using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(Program);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                object[] attributes = method.GetCustomAttributes(false);

                foreach (SoftUniAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}

