using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int realNumber = number;

            int sum = 0;
            int finalSum = 0;

            while (number != 0)
            {
                int digit = number % 10;
                number = number / 10;
                int digitSum = 1;

                for (int i = 1; i <= digit; i++)
                {
                    digitSum = digitSum * i;
                    sum = digitSum;
                }
                finalSum = finalSum + sum;
            }
            if (finalSum == realNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
