public class Bus : Vehicle
{
    private const double workingAirConditionerAdditionalConsumption = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
        this.airConditionerCondition = AirConditionerCondition.On;
    }

    private AirConditionerCondition airConditionerCondition;

    protected override double AdditionalConsumption => 
        airConditionerCondition == AirConditionerCondition.On ? 
        workingAirConditionerAdditionalConsumption : (double)AirConditionerCondition.Off;

    public void SwitchOnAirConditioner()
    {
        this.airConditionerCondition = AirConditionerCondition.On;
    }

    public void SwitchOffAirConditioner()
    {
        this.airConditionerCondition = AirConditionerCondition.Off;
    }
}

