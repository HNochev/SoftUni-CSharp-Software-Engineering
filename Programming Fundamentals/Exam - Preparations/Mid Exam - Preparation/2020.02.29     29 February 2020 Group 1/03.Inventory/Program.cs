using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] command = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "Collect":
                        {
                            if (!(journal.Contains(command[1])))
                            {
                                journal.Add(command[1]);
                            }
                            break;
                        }
                    case "Drop":
                        {
                            journal.Remove(command[1]);
                            break;
                        }
                    case "Combine Items":
                        {
                            string[] oldNewItems = command[1]
                                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
                            if (journal.Contains(oldNewItems[0]))
                            {
                                int index = journal.IndexOf(oldNewItems[0]);
                                journal.Insert(index + 1, oldNewItems[1]);
                            }
                            break;
                        }
                    case "Renew":
                        {
                            if(journal.Contains(command[1]))
                            {
                                journal.Remove(command[1]);
                                journal.Add(command[1]);
                            }
                            break;
                        }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
