using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            int points = 0;

            while (input != "Game over")
            {
                string[] command = input
                    .Split('@', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                switch (command[0])
                {
                    case "Shoot Left":
                        {
                            int startIndex = int.Parse(command[1]);
                            int lenght = int.Parse(command[2]);
                            int counter = 0;

                            if (startIndex >= 0 && startIndex < targets.Count)
                            {
                                for (int i = startIndex; i >= 0; i--)
                                {
                                    if(counter == lenght)
                                    {
                                        if (targets[i] > 5)
                                        {
                                            targets[i] = targets[i] - 5;
                                            points = points + 5;
                                            break;
                                        }
                                        else
                                        {
                                            points = points + targets[i];
                                            targets[i] = targets[i] - targets[i];
                                            break;
                                        }
                                    }
                                    counter++;
                                    if(i == 0)
                                    {
                                        i = targets.Count;
                                    }
                                }
                            }
                        }
                        break;

                    case "Shoot Right":
                        {
                            int startIndex = int.Parse(command[1]);
                            int lenght = int.Parse(command[2]);
                            int counter = 0;

                            if (startIndex >= 0 && startIndex < targets.Count)
                            {

                                for (int i = startIndex; i <= lenght; i++)
                                {
                                    if (counter == lenght)
                                    {
                                        if (targets[i] > 5)
                                        {
                                            targets[i] = targets[i] - 5;
                                            points = points + 5;
                                            break;
                                        }
                                        else
                                        {
                                            points = points + targets[i];
                                            targets[i] = targets[i] - targets[i];
                                            break;
                                        }
                                    }
                                    counter++;
                                    if (i == targets.Count)
                                    {
                                        i = 0;
                                    }
                                }
                            }
                            break;
                        }
                    case "Reverse":
                        {
                            targets.Reverse();
                            break;
                        }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
