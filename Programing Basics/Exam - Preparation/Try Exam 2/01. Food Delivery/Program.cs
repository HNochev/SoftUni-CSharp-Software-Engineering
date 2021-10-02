using System;

namespace _01._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chicken = int.Parse(Console.ReadLine());
            int fish = int.Parse(Console.ReadLine());
            int vegan = int.Parse(Console.ReadLine());

            double fullChickenPrice = chicken * 10.35;
            double fullFishPrice = fish * 12.40;
            double fullVeganPrice = vegan * 8.15;

            double fullPrice = fullChickenPrice + fullFishPrice + fullVeganPrice;

            fullPrice = fullPrice * 1.20;

            Console.WriteLine($"Total: {fullPrice+2.50:f2}");
        }
    }
}
