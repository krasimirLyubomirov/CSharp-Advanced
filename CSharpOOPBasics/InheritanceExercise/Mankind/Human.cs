using System;
using System.Text;

public class Human
{
    private const int LastNameMinLength = 3;
    private const int FirstNameMinLength = 4;
    private const string LengthError = "Expected length at least {0} symbols! Argument: {1}";
    private const string CapitalLetterError = "Expected upper case letter! Argument: {0}";

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            ValidateName(value, nameof(firstName), FirstNameMinLength);
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            ValidateName(value, nameof(lastName), LastNameMinLength);
            lastName = value;
        }
    }

    private static void ValidateName(string value, string type, int minLength)
    {
        if (char.IsLower(value[0]))
        {
            throw new ArgumentException(String.Format(CapitalLetterError, type));
        }

        if (value.Length < minLength)
        {
            throw new ArgumentException(String.Format(LengthError, minLength, type));
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}");

        return builder.ToString().TrimEnd();
    }
}