using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _03.TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "Delete":
                        {
                            if (int.Parse(command[1]) + 1 > 0 && int.Parse(command[1]) + 1 < words.Count)
                            {
                                words.RemoveAt(int.Parse(command[1]) + 1);
                            }
                            break;
                        }
                    case "Swap":
                        {
                            if (words.Contains(command[1]) && words.Contains(command[2]))
                            {
                                int index1 = words.IndexOf(command[1]);
                                int index2 = words.IndexOf(command[2]);

                                words[index1] = command[2];
                                words[index2] = command[1];
                            }
                            break;
                        }
                    case "Put":
                        {
                            
                            if (int.Parse(command[2]) - 1 > 0 && int.Parse(command[2]) - 1 <= words.Count)
                            {
                                words.Insert(int.Parse(command[2]) - 1, command[1]);
                            }
                            break;
                        }
                    case "Sort":
                        {
                            words.Sort();
                            words.Reverse();
                            break;
                        }
                    case "Replace":
                        {
                            if (words.Contains(command[2]))
                            {
                                int index = words.IndexOf(command[2]);
                                words[index] = command[1];
                            }
                            break;
                        }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', words));
        }
    }
}
