using System.Collections.Generic;

public class Team
{
    private List<Person> firstTeam;

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    private List<Person> reserveTeam;

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Team(string name)
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
        this.Name = name;
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40) 
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reserveTeam.Add(person);
        }
    }
}

