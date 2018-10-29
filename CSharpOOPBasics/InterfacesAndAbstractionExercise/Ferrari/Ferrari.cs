using System.Text;

public class Ferrari : IFerrari
{
    public Ferrari(string driverName)
    {
        this.Model = "488-Spider";
        this.DriverName = driverName;
        this.Brakes = "Brakes!";
        this.PushTheGasPedal = "Zadu6avam sA!";
    }

    public string Model { get; }

    public string DriverName { get; }

    public string Brakes { get; }

    public string PushTheGasPedal { get; }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append($"{this.Model}/{this.Brakes}/{this.PushTheGasPedal}/{this.DriverName}");
        return builder.ToString();
    }
}
