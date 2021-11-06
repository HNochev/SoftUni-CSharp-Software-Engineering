using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Stack<char> words = new Stack<char>();

            for (int i = 0; i < word.Length; i++)
            {
                words.Push(word[i]);
            }

            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(words.Pop());
            }
        }
    }
}
