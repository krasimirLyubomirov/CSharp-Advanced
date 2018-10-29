public class Soldiers : ICitizens, IRobots
{
    public Soldiers()
    {

    }

    public Soldiers(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public Soldiers(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }

    public string Name { get; }

    public int Age { get; }

    public string Id { get; }

    public string Model { get; }
}

