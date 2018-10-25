using System;
using System.Text;

public class Worker : Human
{
    private const int MinWorkHours = 1; 
    private const int MaxWorkHours = 12;
    private const int MinSalary = 10;
    private const int WorkDaysPerWeek = 5;

    private const string Error = "Expected value mismatch! Argument: {0}";

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal weekSalary;
    private double workHoursPerDay;

    public decimal WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            if (value <= MinSalary)
            {
                throw new ArgumentException(String.Format(Error, nameof(weekSalary)));
            }

            weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        private set
        {
            if (value < MinWorkHours || value > MaxWorkHours)
            {
                throw new ArgumentException(String.Format(Error, nameof(workHoursPerDay)));
            }

            workHoursPerDay = value;
        }
    }

    public decimal SalaryPerHour => WeekSalary / (decimal)(WorkHoursPerDay * WorkDaysPerWeek);

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder
            .AppendLine(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

        return builder.ToString().TrimEnd();
    }
}