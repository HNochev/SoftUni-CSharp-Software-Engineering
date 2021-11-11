using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] colorClothes = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string[] clothes = colorClothes[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(colorClothes[0]))
                {
                    wardrobe.Add(colorClothes[0], new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    if (!wardrobe[colorClothes[0]].ContainsKey(item))
                    {
                        wardrobe[colorClothes[0]].Add(item,0);
                    }
                    wardrobe[colorClothes[0]][item]++;
                }
            }

            string[] clothesToSearch = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in color.Value)
                {
                    if (color.Key == clothesToSearch[0] && item.Key == clothesToSearch[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
