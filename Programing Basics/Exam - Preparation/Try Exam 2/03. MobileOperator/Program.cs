using System;

namespace _03._MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string years = Console.ReadLine();
            string contract = Console.ReadLine();
            string internet = Console.ReadLine();
            int countMonthsToPay = int.Parse(Console.ReadLine());

            double price = 0;

            switch (contract)
            {
                case "Small":
                    {
                        switch (years)
                        {
                            case "one":
                                {
                                    price = 9.98;
                                    break;
                                }
                            case "two":
                                {
                                    price = 8.58;
                                    break;
                                }
                        }
                        break;
                    }
                case "Middle":
                    {
                        switch (years)
                        {
                            case "one":
                                {
                                    price = 18.99;
                                    break;
                                }
                            case "two":
                                {
                                    price = 17.09;
                                    break;
                                }
                        }
                        break;
                    }
                case "Large":
                    {
                        switch (years)
                        {
                            case "one":
                                {
                                    price = 25.98;
                                    break;
                                }
                            case "two":
                                {
                                    price = 23.59;
                                    break;
                                }
                        }
                        break;
                    }
                case "ExtraLarge":
                    {
                        switch (years)
                        {
                            case "one":
                                {
                                    price = 35.99;
                                    break;
                                }
                            case "two":
                                {
                                    price = 31.79;
                                    break;
                                }
                        }
                        break;
                    }
            }
            if(internet=="yes")
            {
                if(price<=10.00)
                {
                    price = price + 5.50;
                }
                else if(price > 10 && price<=30.00)
                {
                    price = price + 4.35;
                }
                else if(price > 30)
                {
                    price = price + 3.85;
                }
            }
            double finalSum = price * countMonthsToPay;
            if(years == "two")
            {
                finalSum = finalSum * 0.9625;
            }
            Console.WriteLine($"{finalSum:f2} lv.");
        }
    }
}
