using System;
using System.Runtime.ConstrainedExecution;

namespace _10._OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            int finalSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum = evenSum + number;
                }
                else
                {
                    oddSum = oddSum + number;
                }
            }
            finalSum = oddSum - evenSum;
            if (finalSum == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {oddSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(finalSum)}");
            }
        }
    }
}
