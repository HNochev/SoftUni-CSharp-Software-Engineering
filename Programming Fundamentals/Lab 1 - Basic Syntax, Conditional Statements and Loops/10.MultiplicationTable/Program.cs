using System;

namespace _10.MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiply = 0;

            for (int i = 1; i <= 10; i++)
            {
                multiply = number * i;
                Console.WriteLine($"{number} X {i} = {multiply}");
                multiply = 0;
            }
        }
    }
}
