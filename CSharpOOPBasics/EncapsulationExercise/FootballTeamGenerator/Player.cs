using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private const int MinStats = 0;
    private const int MaxStats = 100;

    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    internal string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    private int Endurance
    {
        get
        {
            return this.endurance;
        }

        set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException($"Endurance should be between {MinStats} and {MaxStats}.");
            }

            this.endurance = value;
        }
    }

    private int Sprint
    {
        get
        {
            return this.sprint;
        }

        set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException($"Endurance should be between {MinStats} and {MaxStats}.");
            }

            this.sprint = value;
        }
    }

    private int Dribble
    {
        get
        {
            return this.dribble;
        }

        set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException($"Endurance should be between {MinStats} and {MaxStats}.");
            }

            this.dribble = value;
        }
    }

    private int Passing
    {
        get
        {
            return this.passing;
        }

        set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException($"Endurance should be between {MinStats} and {MaxStats}.");
            }

            this.passing = value;
        }
    }

    private int Shooting
    {
        get
        {
            return this.shooting;
        }

        set
        {
            if (value < MinStats || value > MaxStats)
            {
                throw new ArgumentException($"Endurance should be between {MinStats} and {MaxStats}.");
            }

            this.shooting = value;
        }
    }

    internal int Stats
    {
        get
        {
            return (int)Math.Round((this.Endurance + this.Dribble + this.Sprint + this.Passing + this.Shooting) / 5.0);
        }
    }
}

