using System;

namespace _03._NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int countFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double priceOfOne = 0;
            double finalPrice = 0;

            switch (type)
            {
                case "Roses":
                    {
                        priceOfOne = 5;
                        if (countFlowers > 80)
                        {
                            priceOfOne = priceOfOne * 0.90;
                        }
                        break;
                    }
                case "Dahlias":
                    {
                        priceOfOne = 3.80;
                        if (countFlowers > 90)
                        {
                            priceOfOne = priceOfOne * 0.85;
                        }
                        break;
                    }
                case "Tulips":
                    {
                        priceOfOne = 2.80;
                        if (countFlowers > 80)
                        {
                            priceOfOne = priceOfOne * 0.85;
                        }
                        break;
                    }
                case "Narcissus":
                    {
                        priceOfOne = 3;
                        if (countFlowers < 120)
                        {
                            priceOfOne = priceOfOne * 1.15;
                        }
                        break;
                    }
                case "Gladiolus":
                    {
                        priceOfOne = 2.50;
                        if (countFlowers < 80)
                        {
                            priceOfOne = priceOfOne * 1.20;
                        }
                        break;
                    }
            }
            finalPrice = priceOfOne * countFlowers;

            if((budget-finalPrice) >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {countFlowers} {type} and {(budget-finalPrice):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(budget-finalPrice):f2} leva more.");
            }


        }
    }
}
