namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public StudentSystem()
        {
            this.repo = new Dictionary<string, Student>();
        }

        public void ParseCommand(string commands, Action<string> printFunction)
        {
            string[] args = commands.Split();

            if (args[0] == "Create")
            {
                Create(args[1], args[2], args[3]);
            }
            else if (args[0] == "Show")
            {
                string studentName = args[1];
                if (repo.ContainsKey(studentName))
                {
                    printFunction(repo[studentName].ToString());
                }
            }
        }

        private void Create(string name, string ageString, string gradeString)
        {
            int age = int.Parse(ageString);
            double grade = double.Parse(gradeString);

            if (!repo.ContainsKey(name))
            {
                Student student = new Student(name, age, grade);
                repo[name] = student;
            }
        }
    }
}
