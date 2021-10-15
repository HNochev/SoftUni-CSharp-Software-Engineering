using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] == "ADD")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                else if (command[0] == "INSERT")
                {
                    if (int.Parse(command[2]) >= numbers.Count || int.Parse(command[2]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine().ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
                else if (command[0] == "REMOVE")
                {
                    if (int.Parse(command[1]) >= numbers.Count || int.Parse(command[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine().ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    numbers.RemoveAt(int.Parse(command[1]));
                }
                else if (command[1] == "LEFT")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        numbers.Add(numbers.First());
                        numbers.RemoveAt(0);
                    }
                }
                else if (command[1] == "RIGHT")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        numbers.Insert(0, numbers.Last());
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }

                command = Console.ReadLine().ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
