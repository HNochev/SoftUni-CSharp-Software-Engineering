using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstSecondTry
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            List<int> wariors = new List<int>();

            int plate = 0;
            int warior = 0;

            for (int i = 1; i <= waves; i++)
            {
                wariors = new List<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Add(newPlate);
                }

                while (wariors.Count > 0 && plates.Count > 0)
                {

                    plate = plates[0];
                    plates.RemoveAt(0);

                    warior = wariors[wariors.Count - 1];
                    wariors.RemoveAt(wariors.Count - 1);


                    if (plate > warior)
                    {
                        plate = plate - warior;
                        plates.Insert(0, plate);
                        warior = 0;
                    }
                    else if (plate == warior)
                    {


                    }
                    else if (plate < warior)
                    {
                        warior = warior - plate;
                        wariors.Add(warior);
                        plate = 0;
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
                wariors.Reverse();
                Console.WriteLine($"Orcs left: {string.Join(", ", wariors)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");

                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
