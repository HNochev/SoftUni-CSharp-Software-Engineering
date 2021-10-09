using System;

namespace _05.PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int final = int.Parse(Console.ReadLine());

            for (int i = start; i <= final; i++)
            {
                
                Console.Write($"{(char)i} ");
            }
        }
    }
}
