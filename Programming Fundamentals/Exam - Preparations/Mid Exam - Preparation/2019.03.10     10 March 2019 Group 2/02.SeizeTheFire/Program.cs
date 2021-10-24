using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fires = Console.ReadLine()
                .Split('#', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            int totalFire = 0;

            List<string> result = new List<string>();

            for (int i = 0; i < fires.Length; i++)
            {
                string[] oneFire = fires[i]
                    .Split(" = ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (oneFire[0] == "High" && (int.Parse(oneFire[1]) < 81 || int.Parse(oneFire[1]) > 125))
                {
                    continue;
                }
                else if (oneFire[0] == "Medium" && (int.Parse(oneFire[1]) < 51 || int.Parse(oneFire[1]) > 80))
                {
                    continue;
                }
                else if (oneFire[0] == "Low" && (int.Parse(oneFire[1]) < 1 || int.Parse(oneFire[1]) > 50))
                {
                    continue;
                }


                if (water >= int.Parse(oneFire[1]))
                {
                    totalFire = totalFire + int.Parse(oneFire[1]);
                }
                else
                {
                    continue;
                }

                result.Add(oneFire[1]);

                water = water - int.Parse(oneFire[1]);
                effort = effort + (int.Parse(oneFire[1]) * 0.25);
            }
            Console.WriteLine("Cells:");
            foreach (var item in result)
            {
                Console.WriteLine($" - {item}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
