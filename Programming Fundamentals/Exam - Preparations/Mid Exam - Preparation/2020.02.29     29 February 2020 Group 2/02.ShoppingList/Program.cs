using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopList = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] command = input
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                switch (command[0])
                {
                    case "Urgent":
                        {
                            if (!shopList.Contains(command[1]))
                            {
                                shopList.Insert(0, command[1]);
                            }
                            break;
                        }
                    case "Unnecessary":
                        {
                            shopList.Remove(command[1]);
                            break;
                        }
                    case "Correct":
                        {
                            if (shopList.Contains(command[1]))
                            {
                                int itemIndex = shopList.IndexOf(command[1]);
                                shopList[itemIndex] = command[2];
                            }
                            break;
                        }
                    case "Rearrange":
                        {
                            if (shopList.Contains(command[1]))
                            {
                                shopList.Remove(command[1]);
                                shopList.Add(command[1]);
                            }
                            break;
                        }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", shopList));
        }
    }
}
