using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            PrintRange(first, second);
        }
        static void PrintRange(char a, char b)
        {
            int first = a;
            int second = b;
            if (a > b)
            {
                second = second + first;
                first = second - first;
                second = second - first;
            }
            for (int i = first + 1; i < second; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
