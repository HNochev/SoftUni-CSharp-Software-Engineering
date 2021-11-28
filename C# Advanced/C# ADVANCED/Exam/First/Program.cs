using System;
using System.Collections.Generic;
using System.Linq;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            Stack<int> wariors = new Stack<int>();

            int plate = 0;
            int warior = 0;

            for (int i = 1; i <= waves; i++)
            {
                wariors = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                while (true)
                {
                    if (plate == 0)
                    {
                        plate = plates.Dequeue();
                    }
                    if (warior == 0)
                    {
                        warior = wariors.Pop();
                    }

                    if (plate > warior)
                    {
                        plate = plate - warior;
                        warior = 0;
                    }
                    else if (plate == warior)
                    {
                        warior = 0;
                        plate = 0;
                    }
                    else if (plate < warior)
                    {
                        warior = warior - plate;
                        plate = 0;
                    }

                    if (plates.Count == 0 && plate == 0)
                    {
                        break;
                    }
                    if(wariors.Count == 0 && warior == 0)
                    {
                        break;
                    }
                }
                if (plates.Count == 0 && plate == 0)
                {
                    break;
                }
                if (wariors.Count == 0 && warior == 0 && i == waves)
                {
                    break;
                }
            }
            if (plates.Count == 0 && plate == 0)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                if (warior == 0)
                {
                    Console.WriteLine($"Orcs left: {string.Join(", ", wariors)}");
                }
                else
                {
                    Console.WriteLine($"Orcs left: {warior}, {string.Join(", ", wariors)}");
                }
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                if (plate == 0)
                {
                    Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
                }
                else
                {
                    Console.WriteLine($"Plates left: {plate}, {string.Join(", ", plates)}");
                }
            }
        }
    }
}
