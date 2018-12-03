namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Animals.Bird;
    using WildFarm.Models.Animals.Mammals;
    using WildFarm.Models.Animals.Mammals.Feline;
    using WildFarm.Models.Foods;

    public class Program
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            Animal currentAnimal = null;
            Food currentFood = null;
            int counter = 0;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (counter % 2 == 0)
                {
                    string[] animalInfo = input.Split();
                    currentAnimal = CreateAnimal(animalInfo);
                    Console.WriteLine(currentAnimal.ProducedSound());
                }
                else
                {
                    string[] foodInfo = input.Split();
                    currentFood = CreateFood(foodInfo);
                }

                if (counter % 2 != 0)
                {
                    TryToEat(currentAnimal, currentFood);
                    currentAnimal = null;
                    currentFood = null;
                }

                if (currentAnimal != null)
                {
                    animals.Add(currentAnimal);
                }

                counter++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static void TryToEat(Animal animal, Food food)
        {
            if (animal.GetType().Name.ToLower() == "hen")
            {
                animal.Weight += 0.35 * food.Quantity;
                animal.FoodEaten = food.Quantity;
            }
            else if (animal.GetType().Name.ToLower() == "mouse" &&
                (food.GetType().Name.ToLower() == "vegetable" || food.GetType().Name.ToLower() == "fruit"))
            {
                animal.Weight += 0.10 * food.Quantity;
                animal.FoodEaten = food.Quantity;
            }
            else if (animal.GetType().Name.ToLower() == "cat" &&
                (food.GetType().Name.ToLower() == "vegetable" || food.GetType().Name.ToLower() == "meat"))
            {
                animal.Weight += 0.30 * food.Quantity;
                animal.FoodEaten = food.Quantity;
            }
            else if (animal.GetType().Name.ToLower() == "owl" && food.GetType().Name.ToLower() == "meat")
            {
                animal.Weight += 0.25 * food.Quantity;
                animal.FoodEaten = food.Quantity;
            }
            else if (animal.GetType().Name.ToLower() == "tiger" && food.GetType().Name.ToLower() == "meat")
            {
                animal.Weight += 1 * food.Quantity;
                animal.FoodEaten = food.Quantity;
            }
            else if (animal.GetType().Name.ToLower() == "dog" && food.GetType().Name.ToLower() == "meat")
            {
                animal.Weight += 0.40 * food.Quantity;
                animal.FoodEaten = food.Quantity;
            }
            else
            {
                Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public static Food CreateFood(string[] foodInfo)
        {
            Food food = null;
            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }

            return food;
        }

        public static Animal CreateAnimal(string[] animalInfo)
        {
            Animal animal = null;
            string type = animalInfo[0];

            if (type == "Owl")
            {
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                double wingSize = double.Parse(animalInfo[3]);

                animal = new Owl(name, weight, 0, wingSize);
            }
            else if (type == "Hen")
            {
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                double wingSize = double.Parse(animalInfo[3]);

                animal = new Hen(name, weight, 0, wingSize);
            }
            else if (type == "Mouse")
            {
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                string livingRegion = animalInfo[3];

                animal = new Mouse(name, weight, 0, livingRegion);
            }
            else if (type == "Dog")
            {
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                string livingRegion = animalInfo[3];

                animal = new Dog(name, weight, 0, livingRegion);
            }
            else if (type == "Cat")
            {
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                animal = new Cat(name, weight, 0, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                animal = new Tiger(name, weight, 0, livingRegion, breed);
            }

            return animal;
        }
    }
}
