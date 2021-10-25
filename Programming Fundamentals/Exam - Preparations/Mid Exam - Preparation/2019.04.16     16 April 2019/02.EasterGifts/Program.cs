using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "No Money")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "OutOfStock":
                        {
                            if (gifts.Contains(command[1]))
                            {
                                for (int i = 0; i < gifts.Count; i++)
                                {
                                    if (gifts[i] == command[1])
                                    {
                                        gifts[i] = "None";
                                    }
                                }

                            }
                            break;
                        }
                    case "Required":
                        {
                            int index = int.Parse(command[2]);
                            string gift = command[1];

                            if (index >= 0 && index < gifts.Count)
                            {
                                gifts.RemoveAt(index);
                                gifts.Insert(index, gift);
                            }
                            break;
                        }
                    case "JustInCase":
                        {
                            gifts[gifts.Count - 1] = command[1];
                            break;
                        }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', gifts.Where(x => x != "None")));
        }
    }
}
