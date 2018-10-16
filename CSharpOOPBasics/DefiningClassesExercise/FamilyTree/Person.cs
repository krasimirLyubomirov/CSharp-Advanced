namespace FamilyTree
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        private string name;
        private string birthday;
        private List<Person> parents;
        private List<Person> children;

        public Person()
        {
            this.parents = new List<Person>();
            this.children = new List<Person>();
        }

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public List<Person> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }

        public List<Person> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} {this.Birthday}");
            result.AppendLine($"Parents:");

            if (this.Parents.Any())
            {
                foreach (Person parent in this.Parents)
                {
                    result.AppendLine($"{parent.Name} {parent.Birthday}");
                }
            }

            result.AppendLine($"Children:");

            if (this.Children.Any())
            {
                foreach (Person child in this.Children)
                {
                    result.AppendLine($"{child.Name} {child.Birthday}");
                }
            }

            return result.ToString();
        }
    }
}