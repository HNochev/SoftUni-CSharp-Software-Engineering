using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            while (input[0] != "Sail")
            {
                if (cities.ContainsKey(input[0]))
                {
                    cities[input[0]][0] = cities[input[0]][0] + int.Parse(input[1]);
                    cities[input[0]][1] = cities[input[0]][1] + int.Parse(input[2]);
                }
                else
                {
                    cities.Add(input[0], new List<int>());
                    cities[input[0]].Add(int.Parse(input[1]));
                    cities[input[0]].Add(int.Parse(input[2]));
                }

                input = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Plunder":
                        {
                            string town = input[1];
                            int peopleKilled = int.Parse(input[2]);
                            int goldPlundered = int.Parse(input[3]);

                            cities[town][0] = cities[town][0] - peopleKilled;
                            cities[town][1] = cities[town][1] - goldPlundered;
                            Console.WriteLine($"{town} plundered! {goldPlundered} gold stolen, {peopleKilled} citizens killed.");

                            if (cities[town][0] == 0 || cities[town][1] == 0)
                            {
                                cities.Remove(town);
                                Console.WriteLine($"{town} has been wiped off the map!");
                            }
                            break;
                        }
                    case "Prosper":
                        {
                            string town = input[1];
                            int goldAdded = int.Parse(input[2]);

                            if (goldAdded < 0)
                            {
                                Console.WriteLine("Gold added cannot be a negative number!");
                            }
                            else
                            {
                                cities[town][1] = cities[town][1] + goldAdded;
                                Console.WriteLine($"{goldAdded} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                            }

                            break;
                        }
                    default:
                        break;
                }

                input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
        }
    }
}
