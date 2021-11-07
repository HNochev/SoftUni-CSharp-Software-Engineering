﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if(input[0] == 1)
                {
                    numbers.Push(input[1]);
                }
                else if(!numbers.Any())
                {
                    continue;
                }
                else if(input[0] == 2)
                {
                    numbers.Pop();
                }
                else if(input[0] == 3)
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (input[0] == 4)
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
