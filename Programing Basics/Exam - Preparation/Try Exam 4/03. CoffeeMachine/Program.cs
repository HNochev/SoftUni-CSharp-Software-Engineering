using System;

namespace _03._CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string sugar = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double price = 0;

            switch (type)
            {
                case "Espresso":
                    {
                        switch (sugar)
                        {
                            case "Without":
                                {
                                    price = 0.90;
                                    break;
                                }
                            case "Normal":
                                {
                                    price = 1.00;
                                    break;
                                }
                            case "Extra":
                                {
                                    price = 1.20;
                                    break;
                                }
                        }
                        break;
                    }
                case "Cappuccino":
                    {
                        switch (sugar)
                        {
                            case "Without":
                                {
                                    price = 1.00;
                                    break;
                                }
                            case "Normal":
                                {
                                    price = 1.20;
                                    break;
                                }
                            case "Extra":
                                {
                                    price = 1.60;
                                    break;
                                }
                        }
                        break;
                    }
                case "Tea":
                    {
                        switch (sugar)
                        {
                            case "Without":
                                {
                                    price = 0.50;
                                    break;
                                }
                            case "Normal":
                                {
                                    price = 0.60;
                                    break;
                                }
                            case "Extra":
                                {
                                    price = 0.70;
                                    break;
                                }
                        }
                        break;
                    }
            }
            if (sugar == "Without")
            {
                price = price * 0.65;
            }
            if (type == "Espresso" && count >= 5)
            {
                price = price * 0.75;
            }
            if (count * price > 15)
            {
                price = price * 0.80;
            }
            Console.WriteLine($"You bought {count} cups of {type} for {count * price:f2} lv.");
        }
    }
}
