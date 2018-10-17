namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<Department> departments = new List<Department>();
        private static List<Doctor> doctors = new List<Doctor>();

        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                ParseCommand(commandArgs);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Print(commandArgs);
            }
        }

        private static void Print(string[] commandArgs)
        {
            if (commandArgs.Length == 1)
            {
                string departmentName = commandArgs[0];

                Console.WriteLine(departments.Single(d => d.Name == departmentName).GetAllPatients());
            }
            else if (commandArgs.Length == 2)
            {
                if (commandArgs[1].All(Char.IsDigit))
                {
                    string departmentName = commandArgs[0];
                    int roomNumber = int.Parse(commandArgs[1]);

                    Console.WriteLine(departments.Single(d => d.Name == departmentName).GetPatientsByRoom(roomNumber));
                }
                else
                {
                    string doctorFirstName = commandArgs[0];
                    string doctorLastName = commandArgs[1];

                    Console.WriteLine(doctors.Single(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName).GetPatients());
                }
            }
        }

        private static void ParseCommand(string[] commandArgs)
        {
            string departmentName = commandArgs[0];
            string doctorFirstName = commandArgs[1];
            string doctorLastName = commandArgs[2];
            string patientName = commandArgs[3];

            if (!departments.Any(d => d.Name == departmentName))
            {
                departments.Add(new Department(departmentName));
            }

            Department department = departments.Single(d => d.Name == departmentName);
            Patient patient = new Patient(patientName);

            department.AddPatientToRoom(patient);

            if (!doctors.Any(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName))
            {
                doctors.Add(new Doctor(doctorFirstName, doctorLastName));
            }

            Doctor doctor = doctors.Single(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName);

            doctor.AddPatient(patient);
        }
    }
}
