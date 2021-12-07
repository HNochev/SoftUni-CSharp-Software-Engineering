using _04.WildFarm.Animals;
using _04.WildFarm.Animals.Birds;
using _04.WildFarm.Animals.Mammals;
using _04.WildFarm.Animals.Mammals.Felines;
using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string[] animalInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animalInput[0] == "End")
                {
                    break;
                }

                Animal animal = ProduceAnimal(animalInput);
                Console.WriteLine(animal.ProduceSound());

                string[] foodInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Food food = ProduceFood(foodInput);
                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal}");
            }
        }

        private static Food ProduceFood(string[] input)
        {
            string type = input[0];
            int quantity = int.Parse(input[1]);

            if (type == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                return new Meat(quantity);
            }
            else
            {
                return new Seeds(quantity);
            }
        }

        private static Animal ProduceAnimal(string[] input)
        {
            string type = input[0];
            string name = input[1];
            double weight = double.Parse(input[2]);

            if (type == nameof(Owl))
            {
                double wingSize = double.Parse(input[3]);
                return new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Hen))
            {
                double wingSize = double.Parse(input[3]);
                return new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = input[3];
                return new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = input[3];
                return new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = input[3];
                string breed = input[4];
                return new Cat(name, weight, livingRegion, breed);
            }
            else
            {
                string livingRegion = input[3];
                string breed = input[4];
                return new Tiger(name, weight, livingRegion, breed);
            }
        }
    }
}
