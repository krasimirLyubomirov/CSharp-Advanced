using System;

public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;

        if (fuelQuantity > TankCapacity)
        {
            this.FuelQuantity = 0;
        }
        else
        {
            this.FuelQuantity = fuelQuantity;
        }

        this.FuelConsumption = fuelConsumption;
    }

    protected double FuelQuantity { get; set; }

    public double FuelConsumption { get; private set; }

    public double TankCapacity { get; private set; }

    protected abstract double AdditionalConsumption { get; }

    public string Drive(double distance)
    {
        double requiredFuel = (this.FuelConsumption + this.AdditionalConsumption) * distance;

        if (requiredFuel <= this.FuelQuantity)
        {
            this.FuelQuantity -= requiredFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }

    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException($"Fuel must be a positive number");
        }

        if (fuel + this.FuelQuantity > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }

        this.FuelQuantity += fuel;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}

