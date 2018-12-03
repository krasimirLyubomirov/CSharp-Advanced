public class Product
{
    private string name;
    private decimal price;

    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            Validator.ValidateMoney(value);
            price = value;
        }
    }

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public override string ToString()
    {
        return this.Name;
    }
}

