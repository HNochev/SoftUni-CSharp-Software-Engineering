using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;

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
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plantReal = plant[0];
                int rarity = int.Parse(plant[1]);

                if (plants.ContainsKey(plantReal))
                {
                    plants[plantReal].Clear();
                    plants[plantReal].Add(rarity);
                    plants[plantReal].Add(0);
                    plants[plantReal].Add(0);
                }
                else
                {
                    plants.Add(plantReal, new List<double>());
                    plants[plantReal].Add(rarity);
                    plants[plantReal].Add(0);
                    plants[plantReal].Add(0);
                }
            }

            string[] input = Console.ReadLine()
                .Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            double counter = 0;
            while (input[0] != "Exhibition")
            {
                switch (input[0])
                {
                    case "Rate":
                        {
                            if(!plants.ContainsKey(input[1]))
                            {
                                Console.WriteLine("error");
                                break;
                            }

                            double rating = double.Parse(input[2]);

                            plants[input[1]][1] = plants[input[1]][1] + rating;
                            plants[input[1]][2]++;

                            break;
                        }
                    case "Update":
                        {
                            if (!plants.ContainsKey(input[1]))
                            {
                                Console.WriteLine("error");
                                break;
                            }

                            plants[input[1]][0] = double.Parse(input[2]);
                            break;
                        }
                    case "Reset":
                        {
                            if (!plants.ContainsKey(input[1]))
                            {
                                Console.WriteLine("error");
                                break;
                            }

                            plants[input[1]][1] = 0;
                            plants[input[1]][2] = 0;
                            break;
                        }
                    default:
                        Console.WriteLine("error");
                        break;
                }

                input = Console.ReadLine()
                .Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            }

            foreach (var item in plants)
            {
                if(plants[item.Key][1] == 0 || plants[item.Key][2]== 0)
                {
                    plants[item.Key][1] = 0;
                    continue;
                }
                plants[item.Key][1] = plants[item.Key][1] / plants[item.Key][2];
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {item.Value[1]:f2}");
            }
        }
    }
}
