using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] plant = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                if (plants.ContainsKey(plant[0]))
                {
                    plants[plant[0]][0] = double.Parse(plant[1]);
                }
                else
                {
                    plants.Add(plant[0], new List<double>());
                    plants[plant[0]].Add(double.Parse(plant[1]));
                    plants[plant[0]].Add(0);
                    plants[plant[0]].Add(0);
                }
            }
            string[] command = Console.ReadLine()
                .Split(new char[] { ':', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Exhibition")
            {
                string plantName = command[1];

                switch (command[0])
                {
                    case "Rate":
                        {
                            if (plants.ContainsKey(plantName))
                            {
                                double rating = double.Parse(command[2]);

                                plants[plantName][1] += rating;
                                plants[plantName][2]++;
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                            break;
                        }
                    case "Update":
                        {
                            if (plants.ContainsKey(plantName))
                            {
                                plants[plantName][0] = double.Parse(command[2]);
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                            break;
                        }
                    case "Reset":
                        {
                            if (plants.ContainsKey(plantName))
                            {
                                plants[plantName][1] = 0;
                                plants[plantName][2] = 0;
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("error");
                        break;
                }

                command = Console.ReadLine()
                .Split(new char[] { ':', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in plants)
            {
                if (item.Value[1] == 0 || item.Value[0] == 0)
                {
                    continue;
                }
                item.Value[1] = item.Value[1] / item.Value[2];
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value[0]}; Rating: {plant.Value[1]:f2}");
            }
        }
    }
}
