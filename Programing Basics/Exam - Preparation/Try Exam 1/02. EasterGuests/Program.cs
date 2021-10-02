using System;

namespace _02._EasterGuests
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double countKozunaks = guests / 3.0;
            double countEggs = guests * 2;
            countKozunaks = Math.Ceiling(countKozunaks);

            double priceForKozunaks = countKozunaks * 4;
            double priceEggs = countEggs * 0.45;

            double fullPrice = priceForKozunaks + priceEggs;

            if(budget>=fullPrice)
            {
                Console.WriteLine($"Lyubo bought {Math.Ceiling(countKozunaks)} Easter bread and {countEggs} eggs.");
                Console.WriteLine($"He has {budget-fullPrice:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {fullPrice-budget:f2} lv. more.");
            }
        }
    }
}
