using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> symbols = new Stack<char>();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            if (input[0] == '}' || input[0] == ']' || input[0] == ')')
            {
                Console.WriteLine("NO");
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    symbols.Push(input[i]);
                    continue;
                }
                if (input[i] == ')' && symbols.Peek() == '(')
                {
                    symbols.Pop();
                }
                else if (input[i] == ']' && symbols.Peek() == '[')
                {
                    symbols.Pop();
                }
                else if (input[i] == '}' && symbols.Peek() == '{')
                {
                    symbols.Pop();
                }
            }
            if (symbols.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
