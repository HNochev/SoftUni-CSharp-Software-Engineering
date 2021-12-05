using _09.ExplicitInterfaces.Contracts;
using _09.ExplicitInterfaces.Models;
using System;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                string name = input[0];
                string country = input[1];
                int age = int.Parse(input[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
