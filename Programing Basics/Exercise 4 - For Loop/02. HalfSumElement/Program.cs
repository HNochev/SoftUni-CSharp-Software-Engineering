using System;

namespace _02._HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int finalSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number > max)
                {
                    max = number;
                }
                finalSum = finalSum + number;
            }
            finalSum = finalSum - max;
            if(finalSum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {finalSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(finalSum-max)}");
            }
        }
    }
}
