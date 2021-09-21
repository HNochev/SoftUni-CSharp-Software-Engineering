using System;

namespace _09._LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int finalSum = 0;
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < n; i++)
            {
                int first = int.Parse(Console.ReadLine());
                firstSum = firstSum + first;
            }

            for (int i = 0; i < n; i++)
            {
                int second = int.Parse(Console.ReadLine());
                secondSum = secondSum + second;
            }

            finalSum = firstSum - secondSum;

            if (firstSum == secondSum)
            {
                Console.WriteLine($"Yes, sum = {firstSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(finalSum)}");
            }
        }
    }
}
