using System.Collections.Generic;

public class Person
{
    private string name;
    private int age;
    private List<Person> persons;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public Person()
    {
        this.persons = new List<Person>();
    }
}

