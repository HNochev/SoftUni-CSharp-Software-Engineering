using System;

namespace _01.EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceKgFloor = double.Parse(Console.ReadLine());

            double pricePackEggs = priceKgFloor * 0.75;
            double oneEggPrice = pricePackEggs / 3;

            double priceLiterMilk = priceKgFloor * 1.25;

            double priceFor250MlMilk = priceLiterMilk / 4;


            double oneKozunakPrice = pricePackEggs + priceFor250MlMilk + priceKgFloor;

            int counter = 0;
            int allEggs = 0;

            while (budget >= oneKozunakPrice)
            {
                counter++;
                allEggs = allEggs + 3;
                if(counter%3 ==0)
                {
                    int lostEggs = counter - 2;
                    allEggs = allEggs - lostEggs;
                }
                budget = budget - oneKozunakPrice;
            }

            Console.WriteLine($"You made {counter} cozonacs! Now you have {allEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
