using System;
using System.Linq;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string text = Console.ReadLine();


            foreach (var word in bannedWords)
            {
                string replace = new string('*', word.Length);

                text = text.Replace(word, replace);
            }

            Console.WriteLine(text);
        }
    }
}
