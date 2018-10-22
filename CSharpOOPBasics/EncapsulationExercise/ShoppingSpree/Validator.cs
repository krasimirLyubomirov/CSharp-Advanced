using System;

public class Validator
{
    public static void ValidateMoney(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }
    }

    public static void ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
    }
}

