using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<string> brackets = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brackets.Push(i.ToString());
                }
                if (input[i] == ')')
                {
                    int start = int.Parse(brackets.Pop());
                    string substr = input.Substring(start, i - start + 1);
                    Console.WriteLine(substr);
                }
            }

        }
    }
}
