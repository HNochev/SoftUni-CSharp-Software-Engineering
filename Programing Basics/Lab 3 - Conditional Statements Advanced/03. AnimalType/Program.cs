using System;

namespace _03._AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string classAnimal = Console.ReadLine();

            switch (classAnimal)
            {
                case "dog":
                    {
                        Console.WriteLine("mammal");
                        break;
                    }
                case "crocodile":
                case "tortoise":
                case "snake":
                    {
                        Console.WriteLine("reptile");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("unknown");
                        break;
                    }
            }
        }
    }
}
