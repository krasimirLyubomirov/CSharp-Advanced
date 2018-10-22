using System;
using System.Collections.Generic;
using System.Linq;

public class Dough
{
    private const int MinWeight = 1;
    private const int MaxWeight = 200;
    private const int DefaultMultiplier = 2;

    private Dictionary<string, double> validFlourTypes = new Dictionary<string, double>()
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0
    };

    private Dictionary<string, double> validBakingTechniques = new Dictionary<string, double>()
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private double weight;
    private string flourType;
    private string bakingTechnique;
    private double FlourMultiplier => validFlourTypes[this.FlourType];
    private double BakingTechniqueMultiplier => validBakingTechniques[this.BakingTechnique];
    public double Calories => DefaultMultiplier * this.Weight * FlourMultiplier * BakingTechniqueMultiplier;

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
            }

            weight = value;
        }
    }

    public string FlourType
    {
        get { return flourType; }
        set
        {
            ValidateTypes(value, validFlourTypes);
            flourType = value.ToLower();
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            ValidateTypes(value, validBakingTechniques);
            bakingTechnique = value.ToLower();
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    private static void ValidateTypes(string type, Dictionary<string, double> dictionary)
    {
        if (dictionary.Any(f => f.Key == type.ToLower()) == false)
        {
            throw new ArgumentException("Invalid type of dough.");
        }
    }
}

