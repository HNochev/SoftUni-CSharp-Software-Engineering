using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while(input != "end")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch(command[0])
                {
                    case "swap":
                        {
                            int insertElement = numbers[int.Parse(command[1])];
                            numbers[int.Parse(command[1])] = numbers[int.Parse(command[2])];
                            numbers[int.Parse(command[2])] = insertElement;
                            break;
                        }
                    case "multiply":
                        {
                            numbers[int.Parse(command[1])] = numbers[int.Parse(command[1])] * numbers[int.Parse(command[2])];
                            break;
                        }
                    case "decrease":
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                numbers[i] = numbers[i] - 1;
                            }
                            break;
                        }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
