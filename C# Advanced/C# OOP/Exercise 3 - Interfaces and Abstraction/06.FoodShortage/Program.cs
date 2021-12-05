using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    string id = input[2];
                    string birthdate = input[3];

                    buyersByName.Add(name, new Citizen(name, age, id, birthdate));
                }
                else if (input.Length == 3)
                {
                    string group = input[2];

                    buyersByName.Add(name, new Rebel(name, age, group));
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (buyersByName.ContainsKey(name))
                {
                    IBuyer buyer = buyersByName[name];

                    buyer.BuyFood();
                }

            }
            int totalFood = buyersByName.Sum(x => x.Value.Food);

            Console.WriteLine(totalFood);
        }
    }
}
