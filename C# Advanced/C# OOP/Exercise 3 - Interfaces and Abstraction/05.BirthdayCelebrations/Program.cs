using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birthdate = input[4];

                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if(input[0] == "Pet")
                {
                    string name = input[1];
                    string birthdate = input[2];

                    birthables.Add(new Pet(name, birthdate));
                }
            }

            string yeatToFilter = Console.ReadLine();

            foreach (var birthable in birthables.Where(x=>x.Birthdate.EndsWith(yeatToFilter)))
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}
