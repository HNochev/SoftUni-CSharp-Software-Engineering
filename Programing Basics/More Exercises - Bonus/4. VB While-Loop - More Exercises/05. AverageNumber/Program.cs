using System;

namespace _05._AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double finalSum = 0;
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                double sum = double.Parse(Console.ReadLine());
                finalSum = finalSum + sum;
                counter++;
            }
            Console.WriteLine($"{finalSum / counter:f2}");
        }
    }
}
