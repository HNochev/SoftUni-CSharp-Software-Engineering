using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            while (command != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int, int> func = GetFunc(command);
                    numbers = numbers.Select(func).ToList();
                }

                command = Console.ReadLine();
            }
        }

        static Func<int, int> GetFunc(string command)
        {
            switch (command)
            {
                case "add":
                    {
                        return n => n = n + 1;
                    }
                case "multiply":
                    {
                        return n => n = n * 2;
                    }
                case "subtract":
                    {
                        return n => n = n - 1;
                    }
                default:
                    return null;
            }
        }
    }
}
