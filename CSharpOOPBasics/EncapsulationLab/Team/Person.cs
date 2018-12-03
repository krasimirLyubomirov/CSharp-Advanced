using System;

public class Person
{
    const decimal MinSalary = 460;
    const int MinLength = 3;

    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value?.Length < MinLength)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

            firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value?.Length < MinLength)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            lastName = value;
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer!");
            }

            age = value;
        }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < MinSalary)
            {
                throw new ArgumentException($"Salary cannot be less than {MinSalary} leva!");
            }

            salary = value;
        }
    }


    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary) : this(firstName, lastName, age)
    {
        this.Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age > 30)
        {
            this.Salary += this.Salary * (percentage / 100);
        }
        else
        {
            this.Salary += this.Salary * (percentage / 200);
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
    }
}

