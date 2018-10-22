using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> Products { get; set; }

    public string Name
    {
        get { return name; }
        set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            Validator.ValidateMoney(value);
            money = value;
        }
    }

    public Person()
    {
        this.Products = new List<Product>();
    }

    public Person(string name, decimal money):this()
    {
        this.Name = name;
        this.Money = money;
    }

    public string TryBuyProduct(Product product)
    {
        if (this.Money < product.Price)
        {
            return $"{this.Name} can't afford {product.Name}";
        }

        this.Money -= product.Price;
        this.Products.Add(product);
        return $"{this.Name} bought {product.Name}";
    }

    public override string ToString()
    {
        string productsOutput = this.Products.Count > 0 ? string.Join(", ", this.Products) : "Nothing bought";
        string result = $"{this.Name} - {productsOutput}";

        return result;
    }
}

