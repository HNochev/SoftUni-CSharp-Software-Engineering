using System;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyPrice = float.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double savedMoney = 0;

            for (int i = 1; i <= months; i++)
            {
                if (i % 4 == 0)
                {
                    savedMoney = savedMoney + (savedMoney * 0.25);
                }

                if (i % 2 == 1 && i != 1)
                {
                    savedMoney = savedMoney - (savedMoney * 0.16);
                }
                savedMoney = savedMoney + (journeyPrice * 0.25);

            }
            if (savedMoney >= journeyPrice)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {(savedMoney - journeyPrice):f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {Math.Abs(savedMoney - journeyPrice):f2}lv. more.");
            }
        }
    }
}
