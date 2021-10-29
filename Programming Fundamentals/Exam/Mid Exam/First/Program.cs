using System;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPrunder = double.Parse(Console.ReadLine());

            double finalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0)
                {
                    finalPlunder = finalPlunder + dailyPlunder * 1.50;
                }
                else
                {
                    finalPlunder = finalPlunder + dailyPlunder;
                }

                if (i % 5 == 0)
                {
                    finalPlunder = finalPlunder * 0.70;
                }
            }
            if(finalPlunder >= expectedPrunder)
            {
                Console.WriteLine($"Ahoy! {finalPlunder:f2} plunder gained.");
            }
            else if(finalPlunder < expectedPrunder)
            {
                double percentage = (finalPlunder / expectedPrunder)*100;

                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
