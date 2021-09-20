using System;

namespace _04._FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int countFishermans = int.Parse(Console.ReadLine());
            double priceForRent = 0;

            switch (season)
            {
                case "Spring":
                    {
                        priceForRent = 3000;
                        break;
                    }
                case "Summer":
                    {
                        priceForRent = 4200;
                        break;
                    }
                case "Autumn":
                    {
                        priceForRent = 4200;
                        break;
                    }
                case "Winter":
                    {
                        priceForRent = 2600;
                        break;
                    }
            }
            if (countFishermans <= 6)
            {
                priceForRent = priceForRent * 0.90;
            }
            else if (countFishermans > 6 && countFishermans <= 11)
            {
                priceForRent = priceForRent * 0.85;
            }
            else if (countFishermans > 11)
            {
                priceForRent = priceForRent * 0.75;
            }

            if (countFishermans % 2 == 0 && season != "Autumn")
            {
                priceForRent = priceForRent * 0.95;
            }

            double finalMoney = budget - priceForRent;

            if(finalMoney >= 0)
            {
                Console.WriteLine($"Yes! You have {finalMoney:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(finalMoney):f2} leva.");
            }
        }
    }
}
