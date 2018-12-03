using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Department> departments = new List<Department>();
        int peopleCount = int.Parse(Console.ReadLine());

        for (int person = 0; person < peopleCount; person++)
        {
            string[] personInformation = Console.ReadLine().Split();
            string departmentName = personInformation[3];

            if (!departments.Any(d => d.Name == departmentName))
            {
                Department dep = new Department(departmentName);
                departments.Add(dep);
            }

            Department department = departments.FirstOrDefault(d => d.Name == departmentName);
            Employee employee = ParseEmployee(personInformation);
            department.AddEmployee(employee);
        }

        Department highestAverageDepartment = departments.OrderByDescending(d => d.AverageSalary).First();
        Console.WriteLine($"Highest Average Salary: {highestAverageDepartment.Name}");
        foreach (var employee in highestAverageDepartment.Employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }

    public static Employee ParseEmployee(string[] personInformation)
    {
        string name = personInformation[0];
        decimal salary = decimal.Parse(personInformation[1]);
        string position = personInformation[2];
        string email = "n/a";
        int age = -1;

        if (personInformation.Length == 6)
        {
            email = personInformation[4];
            age = int.Parse(personInformation[5]);
        }
        else if (personInformation.Length == 5)
        {
            bool isAge = int.TryParse(personInformation[4], out age);
            if (!isAge)
            {
                email = personInformation[4];
                age = -1;
            }
        }

        Employee employee = new Employee(name, position, salary, age, email);
        return employee;
    }
}

