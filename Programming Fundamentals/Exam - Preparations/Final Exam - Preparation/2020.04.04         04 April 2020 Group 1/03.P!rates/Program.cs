using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Cities
    {
        public string Town { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public Cities(string town, int population, int gold)
        {
            this.Town = town;
            this.Population = population;
            this.Gold = gold;
        }
        public override string ToString()
        {
            return $"{Town} -> Population: {Population} citizens, Gold: {Gold} kg";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Cities> towns = new List<Cities>();

            while (command[0] != "Sail")
            {
                Cities city = new Cities(command[0], int.Parse(command[1]), int.Parse(command[2]));

                if (towns.Select(x=>x.Town).Contains(city.Town))
                {
                    Cities c = towns.Where(x => x.Town == city.Town).FirstOrDefault();

                    c.Population = c.Population + city.Population;
                    c.Gold = c.Gold + city.Gold;
                }
                else
                {
                    towns.Add(city);
                }
                command = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            string[] input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Plunder":
                        {
                            string town = input[1];
                            int people = int.Parse(input[2]);
                            int gold = int.Parse(input[3]);

                            Cities c = towns.Where(x => x.Town == town).FirstOrDefault();

                            c.Population = c.Population - people;
                            c.Gold = c.Gold - gold;

                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                            if (c.Population == 0 | c.Gold == 0)
                            {
                                Console.WriteLine($"{town} has been wiped off the map!");
                                towns.Remove(c);
                            }

                            break;
                        }
                    case "Prosper":
                        {
                            string town = input[1];
                            int gold = int.Parse(input[2]);

                            if (gold <= 0)
                            {
                                Console.WriteLine("Gold added cannot be a negative number!");
                                input = Console.ReadLine()
                            .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                                continue;
                            }

                            Cities c = towns.Where(x => x.Town == town).FirstOrDefault();

                            c.Gold = c.Gold + gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {c.Gold} gold.");

                            break;
                        }
                }

                input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            if(towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (var item in towns.OrderByDescending(x => x.Gold).ThenBy(x => x.Town))
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
