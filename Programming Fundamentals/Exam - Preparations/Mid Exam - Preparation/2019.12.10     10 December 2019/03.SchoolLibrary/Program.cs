using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = Console.ReadLine()
                .Split('&', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] input = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "Done")
            {
                switch (input[0])
                {
                    case "Add Book":
                        {
                            if (!(shelf.Contains(input[1])))
                            {
                                shelf.Insert(0, input[1]);
                            }
                            break;
                        }
                    case "Take Book":
                        {
                            shelf.Remove(input[1]);
                            break;
                        }
                    case "Swap Books":
                        {
                            if (shelf.Contains(input[1]) && shelf.Contains(input[2]))
                            {
                                int index1 = shelf.IndexOf(input[1]);
                                int index2 = shelf.IndexOf(input[2]);

                                shelf[index1] = input[2];
                                shelf[index2] = input[1];
                            }
                            break;
                        }
                    case "Insert Book":
                        {
                            shelf.Add(input[1]);
                            break;
                        }
                    case "Check Book":
                        {
                            if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < shelf.Count)
                            {
                                Console.WriteLine($"{shelf[int.Parse(input[1])]}");
                            }
                            break;
                        }
                }

                input = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine(string.Join(", ", shelf));
        }
    }
}
