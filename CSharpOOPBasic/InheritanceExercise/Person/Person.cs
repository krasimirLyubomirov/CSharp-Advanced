using System;
using System.Text;

public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }

            name = value;
        }
    }

    public virtual int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append($"Name: {this.Name.Trim()}, Age: {this.Age}");

        return builder.ToString();
    }
}

