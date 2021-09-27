using System;

namespace _08._FuelTankPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            string card = Console.ReadLine();
            double gasoline = 2.22;
            double diesel = 2.33;
            double gas = 0.93;
            double finalPrice = 0;

                if(card == "Yes")
                    {
                        gasoline = gasoline - 0.18;
                        diesel = diesel - 0.12;
                        gas = gas - 0.08;
                    }
            switch (fuel)
            {
                case "Gas":
                    {
                        finalPrice = gas * quantity;
                        break;
                    }
                case "Gasoline":
                    {
                        finalPrice = gasoline * quantity;
                        break;
                    }
                case "Diesel":
                    {
                        finalPrice = diesel * quantity;
                        break;
                    }
            }
            if (quantity > 20 && quantity <= 25)
            {
                finalPrice = finalPrice * 0.92;
            }
            else if (quantity > 25)
            {
                finalPrice = finalPrice * 0.90;
            }

            Console.WriteLine($"{finalPrice:f2} lv.");
        }
    }
}
