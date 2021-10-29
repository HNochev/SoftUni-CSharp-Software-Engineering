using System;
using System.Collections.Generic;
using System.Linq;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            List<string> newDeck = new List<string>();

            while (input != "Ready")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (command[0])
                {
                    case "Add":
                        {
                            if(cards.Contains(command[1]))
                            {
                                newDeck.Add(command[1]);
                            }
                            else
                            {
                                Console.WriteLine("Card not found.");
                            }
                            break;
                        }
                    case "Insert":
                        {
                            int index = int.Parse(command[2]);
                            if(index >= 0 && index < newDeck.Count && cards.Contains(command[1]))
                            {
                                newDeck.Insert(index, command[1]);
                            }
                            else
                            {
                                Console.WriteLine("Error!");
                            }
                            break;
                        }
                    case "Remove":
                        {
                            if (newDeck.Contains(command[1]))
                            {
                                newDeck.Remove(command[1]);
                            }
                            else
                            {
                                Console.WriteLine("Card not found.");
                            }
                            break;
                        }
                    case "Swap":
                        {
                            int index1 = newDeck.IndexOf(command[1]);
                            int index2 = newDeck.IndexOf(command[2]);

                            newDeck[index1] = command[2];
                            newDeck[index2] = command[1];
                            break;
                        }
                    case "Shuffle":
                        {
                            newDeck.Reverse();
                            break;
                        }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', newDeck));
        }
    }
}
