using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "Include":
                        {
                            shops.Add(command[1]);
                            break;
                        }
                    case "Visit":
                        {
                            if (shops.Count >= int.Parse(command[2]))
                            {
                                if (command[1] == "first")
                                {
                                    shops.RemoveRange(0, int.Parse(command[2]));
                                }
                                else if (command[1] == "last")
                                {
                                    shops.RemoveRange((shops.Count) - int.Parse(command[2]), int.Parse(command[2]));
                                }
                            }
                            break;
                        }
                    case "Prefer":
                        {
                            int index1 = int.Parse(command[1]);
                            int index2 = int.Parse(command[2]);

                            if (index1 >= 0 && index2 >= 0 && index1 < shops.Count && index2 < shops.Count)
                            {
                                string shop1 = shops[index1];
                                shops[index1] = shops[index2];
                                shops[index2] = shop1;
                            }

                            break;
                        }
                    case "Place":
                        {
                            int index = int.Parse(command[2]);

                            if (index + 1 > 0 && index + 1 < shops.Count)
                            {
                                shops.Insert(index + 1, command[1]);
                            }
                            break;
                        }
                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(' ', shops));
        }
    }
}
