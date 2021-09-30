using System;

namespace _01._Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int detergentBottles = int.Parse(Console.ReadLine());
            double detergentQuantity = detergentBottles * 750;
            double detergentUsed = 0;
            string dishes = "0";
            double allDishes = 0;
            double allPots = 0;
            double counter = 0;
            while (dishes != "End")
            {
                int dishesInt = int.Parse(dishes);
                if (counter % 3 == 0)
                {
                    counter = 0;
                    allPots = allPots + dishesInt;
                    detergentUsed = dishesInt * 15;
                    if (detergentQuantity < detergentUsed)
                    {
                        break;
                    }
                    detergentQuantity = detergentQuantity - detergentUsed;
                }
                else
                {
                    allDishes = allDishes + dishesInt;
                    detergentUsed = dishesInt * 5;
                    if (detergentQuantity <= detergentUsed)
                    {
                        break;
                    }
                    detergentQuantity = detergentQuantity - detergentUsed;
                }
                counter++;
                dishes = Console.ReadLine();
            }
            if (dishes == "End")
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{allDishes} dishes and {allPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergentQuantity} ml.");
            }
            else if (detergentQuantity <= detergentUsed)
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(detergentQuantity - detergentUsed)} ml. more necessary!");
            }
        }
    }
}
