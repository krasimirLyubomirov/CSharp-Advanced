using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MinLength = 1;
    private const int MaxLength = 15;
    private const int MinToppings = 0;
    private const int MaxToppings = 10;
    private string name;
    private Dough Dough { get; set; }
    private List<Topping> Toppings { get; set; }
    private double ToppingsCalories
    {
        get
        {
            if (this.Toppings.Count == 0)
            {
                return 0;
            }

            return this.Toppings.Select(t => t.Calories).Sum();
        }
    }

    private double Calories => this.Dough.Calories + this.ToppingsCalories;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || value.Length > MaxLength)
            {
                throw new ArgumentException($"Pizza name should be between {MinLength} and {MaxLength} symbols.");
            }

            name = value;
        }
    }

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name):this()
    {
        this.Name = name;
    }

    public void SetDough(Dough dough)
    {
        if (this.Dough != null)
        {
            throw new InvalidOperationException("Dough already set!");
        }

        this.Dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count > MaxToppings)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
        }
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:f2} Calories.";
    }
}

