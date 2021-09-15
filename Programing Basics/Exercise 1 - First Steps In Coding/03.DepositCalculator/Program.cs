using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            int period = int.Parse(Console.ReadLine());
            double yearInterest = double.Parse(Console.ReadLine());

            double stackedInterest = sum * (yearInterest / 100);
            double oneMonthInterest = stackedInterest / 12;
            double finalSum = sum + (period * oneMonthInterest);

            Console.WriteLine(finalSum);
        }
    }
}
