using System;

namespace _11._CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            int countOfToys = 0;
            double moneyEveryTime = 10;
            double finalMoney = 0;
            double finalToysPrice = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    finalMoney = finalMoney + moneyEveryTime;
                    moneyEveryTime = moneyEveryTime + 10;
                    finalMoney--;
                }
                else
                {
                    countOfToys = countOfToys + 1;
                }    
            }
            finalToysPrice = countOfToys * toysPrice;
            finalMoney = finalMoney + finalToysPrice;
            
            if(finalMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {(finalMoney - washingMachinePrice):f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(finalMoney-washingMachinePrice):f2}");
            }
        }
    }
}
