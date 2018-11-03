namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name { get; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string ProducedSound();
    }
}
