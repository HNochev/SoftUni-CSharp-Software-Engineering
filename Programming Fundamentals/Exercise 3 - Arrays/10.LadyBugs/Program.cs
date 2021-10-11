using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());

            int[] indexesOfLaybugs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[sizeOfField];

            for (int i = 0; i < sizeOfField; i++)
            {
                for (int j = 0; j < indexesOfLaybugs.Length; j++)
                {
                    if (i == indexesOfLaybugs[j])
                    {
                        field[i] = 1;
                    }
                }
            }

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] stringArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int ladybugIndex = int.Parse(stringArray[0]);
                string direction = stringArray[1];
                int flyLenght = int.Parse(stringArray[2]);

                if (ladybugIndex < 0 || ladybugIndex > field.Length - 1 || field[ladybugIndex] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }

                field[ladybugIndex] = 0;

                if (direction == "right")
                {
                    int landIndex = ladybugIndex + flyLenght;

                    if (landIndex > field.Length - 1)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if (field[landIndex] == 1)
                    {
                        while (field[landIndex] == 1)
                        {
                            landIndex = landIndex + flyLenght;
                            if (landIndex > field.Length - 1)
                            {
                                break;
                            }
                        }
                    }
                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {
                        field[landIndex] = 1;
                    }
                }
                else if (direction == "left")
                {
                    int landIndex = ladybugIndex - flyLenght;

                    if (landIndex < 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if (field[landIndex] == 1)
                    {
                        while (field[landIndex] == 1)
                        {
                            landIndex = landIndex - flyLenght;
                            if (landIndex < 0)
                            {
                                break;
                            }
                        }
                    }
                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {
                        field[landIndex] = 1;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ', field));
        }
    }
}
