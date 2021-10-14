using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.ListManipulationAdvanced
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
            bool isChanged = false;

            while (input[0].ToUpper() != "END")
            {
                switch (input[0].ToUpper())
                {
                    case "ADD":
                        {
                            numbers.Add(int.Parse(input[1]));
                            isChanged = true;
                            break;
                        }
                    case "REMOVE":
                        {
                            numbers.Remove(int.Parse(input[1]));
                            isChanged = true;
                            break;
                        }
                    case "REMOVEAT":
                        {
                            numbers.RemoveAt(int.Parse(input[1]));
                            isChanged = true;
                            break;
                        }
                    case "INSERT":
                        {
                            numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                            isChanged = true;
                            break;
                        }
                    case "CONTAINS":
                        {
                            if (numbers.Contains(int.Parse(input[1])))
                            {
                                Console.WriteLine("Yes");
                            }
                            else
                            {
                                Console.WriteLine("No such number");
                            }
                            break;
                        }
                    case "PRINTEVEN":
                        {
                            Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 == 0)));
                            break;
                        }
                    case "PRINTODD":
                        {
                            Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 != 0)));
                            break;
                        }
                    case "GETSUM":
                        {
                            Console.WriteLine(numbers.Sum());
                            break;
                        }
                    case "FILTER":
                        {
                            switch (input[1])
                            {
                                case "<":
                                    {
                                        Console.WriteLine(string.Join(' ', numbers.Where(n => n < int.Parse(input[2]))));
                                        break;
                                    }
                                case ">":
                                    {
                                        Console.WriteLine(string.Join(' ', numbers.Where(n => n > int.Parse(input[2]))));
                                        break;
                                    }
                                case ">=":
                                    {
                                        Console.WriteLine(string.Join(' ', numbers.Where(n => n >= int.Parse(input[2]))));
                                        break;
                                    }
                                case "<=":
                                    {
                                        Console.WriteLine(string.Join(' ', numbers.Where(n => n <= int.Parse(input[2]))));
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    default:
                        break;
                }

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
