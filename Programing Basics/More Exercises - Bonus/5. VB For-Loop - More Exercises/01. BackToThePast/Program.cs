using System;

namespace _01._BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int toYear = int.Parse(Console.ReadLine());
            int age = 18;

            for (int startYear = 1800; startYear <= toYear; startYear++)
            {
                if (startYear % 2 == 0)
                {
                    money = money - 12000;
                }
                else
                {
                    money = money - (12000 + 50 * age);
                }
                age++;
            }
            if (money >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {money:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(money):f2} dollars to survive.");
            }
        }
    }
}
