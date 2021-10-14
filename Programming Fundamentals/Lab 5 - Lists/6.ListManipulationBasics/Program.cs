using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0].ToUpper() != "END")
            {
                switch (input[0].ToUpper())
                {
                    case "ADD":
                        {
                            numbers.Add(int.Parse(input[1]));
                            break;
                        }
                    case "REMOVE":
                        {
                            numbers.Remove(int.Parse(input[1]));
                            break;
                        }
                    case "REMOVEAT":
                        {
                            numbers.RemoveAt(int.Parse(input[1]));
                            break;
                        }
                    case "INSERT":
                        {
                            numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                            break;
                        }
                    default:
                        break;
                }

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
