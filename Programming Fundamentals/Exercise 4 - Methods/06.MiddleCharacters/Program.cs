using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            MiddleChar(text);
        }
        static void MiddleChar(string text)
        {
            int middle = text.Length / 2;
            if (text.Length % 2 == 0)
            {
                Console.WriteLine($"{text[middle - 1]}{text[middle]}");
            }
            else
            {
                Console.WriteLine(text[middle]);
            }
        }
    }
}
