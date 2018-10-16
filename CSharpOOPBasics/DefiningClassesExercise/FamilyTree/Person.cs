namespace FamilyTree
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string firstName;
        private string lastName;
        private string bithDate;
        private List<Person> parents;
        private List<Person> childrens;

        public Person()
        {
            this.childrens = new List<Person>();
            this.parents = new List<Person>();
        }

        public Person(string firstName, string lastName)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Person(string birthdate)
            : this()
        {
            this.BirthDate = birthdate;
        }

        public string BirthDate
        {
            get { return bithDate; }
            set { bithDate = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public List<Person> Childrens
        {
            get { return this.childrens; }
            set { this.childrens = value; }
        }

        public List<Person> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }

        public void AddChild(Person child)
        {
            this.childrens.Add(child);
        }

        public void AddParent(Person parent)
        {
            this.parents.Add(parent);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{this.FirstName} {this.LastName} {this.BirthDate}");
            builder.AppendLine("Parents:");

            foreach (var parent in parents)
            {
                builder.AppendLine($"{parent.FirstName} {parent.LastName} {parent.BirthDate}");
            }

            builder.AppendLine("Children:");

            foreach (var child in childrens)
            {
                builder.Append($"{child.FirstName} {child.LastName} {child.BirthDate}");
            }

            return builder.ToString();
        }
    }
}