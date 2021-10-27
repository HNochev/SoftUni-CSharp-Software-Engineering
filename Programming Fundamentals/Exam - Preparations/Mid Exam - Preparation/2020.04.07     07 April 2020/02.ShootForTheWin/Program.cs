using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input = Console.ReadLine();
            int counter = 0;
            int indexValue = 0;

            while (input != "End")
            {
                int index = int.Parse(input);
                if (index >= 0 && index < targets.Count)
                {
                    indexValue = targets[index];
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] == -1)
                        {
                            continue;
                        }
                        if (targets[index] == -1)
                        {
                            break;
                        }

                        if (targets[i] > indexValue)
                        {
                            targets[i] = targets[i] - indexValue;
                        }
                        else if (targets[i] <= indexValue)
                        {
                            targets[i] = targets[i] + indexValue;
                        }
                    }
                    targets[index] = -1;
                }
                input = Console.ReadLine();
            }
            counter = targets.Count(x => x == -1);

            Console.Write($"Shot targets: {counter} -> ");
            Console.Write(string.Join(' ', targets));
        }
    }
}
