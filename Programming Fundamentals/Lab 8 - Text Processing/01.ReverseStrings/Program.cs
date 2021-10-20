using System;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "end")
            {
                Console.WriteLine($"{word} = {string.Join("",word.ToCharArray().Reverse())}");

                word = Console.ReadLine();
            }
        }
    }
}
