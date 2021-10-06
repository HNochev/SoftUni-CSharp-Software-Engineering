using System;

namespace _09.SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int oddNumbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i < oddNumbers * 2; i = i + 2)
            {
                Console.WriteLine(i);
                sum = sum + i;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
