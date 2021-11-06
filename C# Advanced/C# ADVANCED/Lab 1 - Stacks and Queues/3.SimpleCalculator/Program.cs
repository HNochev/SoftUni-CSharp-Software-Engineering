using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int a = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int b = int.Parse(stack.Pop());
                int sum = 0;

                if (sign == "+")
                {
                    sum = a + b;
                }
                else
                {
                    sum = a - b;
                }
                stack.Push(sum.ToString());
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
