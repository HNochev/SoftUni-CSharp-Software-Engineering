using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double beginSum = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double simpleSum = beginSum;
            double previousSum = beginSum;
            double complexSum = previousSum;

            for (int i = 1; i <= months; i++)
            {
                simpleSum = simpleSum + (beginSum * 0.03);
                complexSum = complexSum + (previousSum * 0.027);
                previousSum = complexSum;
            }
            Console.WriteLine($"Simple interest rate: {simpleSum:f2} lv.");
            Console.WriteLine($"Complex interest rate: {complexSum:f2} lv.");

            if (simpleSum >= complexSum)
            {
                Console.WriteLine($"Choose a simple interest rate. You will win {simpleSum-complexSum:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {complexSum - simpleSum:f2} lv.");
            }
        }
    }
}
