namespace PersonInfo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthDate = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, id, birthDate);
            IBirthable birthable = new Citizen(name, age, id, birthDate);

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
