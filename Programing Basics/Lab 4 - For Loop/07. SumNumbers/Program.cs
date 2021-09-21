using System;

namespace _07._SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int finalSum = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                finalSum = finalSum + number;
            }
            Console.WriteLine(finalSum);
        }
    }
}
