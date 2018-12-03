using System.Linq;
using System.Text;

public class Smartphone : ICall, IBrowse
{
    public Smartphone(string model)
    {
        this.Model = model;
    }

    private string Model { get; }

    public string Call(string phoneNumber)
    {
        bool hasCharacter = phoneNumber.Any(char.IsLetter);

        if (hasCharacter)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Invalid number!");
            return builder.ToString();
        }
        else
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Calling... {phoneNumber}");
            return builder.ToString();
        }
    }

    public string Browse(string sites)
    {
        bool hasDigit = sites.Any(char.IsDigit);

        if (hasDigit)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Invalid URL!");
            return builder.ToString();
        }
        else
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Browsing: {sites}!");
            return builder.ToString();
        }
    }
}

