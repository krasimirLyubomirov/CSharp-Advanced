public class Pet : IBirthable
{
    public string Name { get; private set; }
    public string BirthDate { get; private set; }

    public Pet(string name, string birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }
}

