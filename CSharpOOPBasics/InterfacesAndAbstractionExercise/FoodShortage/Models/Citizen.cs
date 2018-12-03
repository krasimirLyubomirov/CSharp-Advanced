public class Citizen : IIdentifiable, IBirthable, IBuyer, IAge
{
    public Citizen(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
    }

    public string Id { get; }

    public string BirthDate { get; }

    public string Name { get; }

    public int Food { get; private set; }

    public int Age { get; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

