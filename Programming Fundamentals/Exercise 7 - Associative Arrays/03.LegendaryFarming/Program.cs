using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            bool isDone = false;

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            while (true)
            {
                string[] items = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 1; i < items.Length; i = i + 2)
                {
                    if (keyMaterials.ContainsKey(items[i]))
                    {
                        keyMaterials[items[i]] = keyMaterials[items[i]] + int.Parse(items[i - 1]);
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(items[i]))
                        {
                            junkMaterials[items[i]] = junkMaterials[items[i]] + int.Parse(items[i - 1]);
                        }
                        else
                        {
                            junkMaterials.Add(items[i], int.Parse(items[i - 1]));
                        }
                    }

                    if (keyMaterials.ContainsKey("shards") && keyMaterials["shards"] >= 250)
                    {
                        keyMaterials["shards"] = keyMaterials["shards"] - 250;

                        Console.WriteLine("Shadowmourne obtained!");
                        isDone = true;
                        break;
                    }
                    else if (keyMaterials.ContainsKey("fragments") && keyMaterials["fragments"] >= 250)
                    {
                        keyMaterials["fragments"] = keyMaterials["fragments"] - 250;

                        Console.WriteLine("Valanyr obtained!");
                        isDone = true;
                        break;
                    }
                    else if (keyMaterials.ContainsKey("motes") && keyMaterials["motes"] >= 250)
                    {
                        keyMaterials["motes"] = keyMaterials["motes"] - 250;

                        Console.WriteLine("Dragonwrath obtained!");
                        isDone = true;
                        break;
                    }
                }
                if(isDone)
                {
                    break;
                }
                input = Console.ReadLine().ToLower();
            }

            foreach (var item in keyMaterials.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkMaterials.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
