using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            string laps = Console.ReadLine();
            string fanCard = Console.ReadLine();
            string typeKart = Console.ReadLine();

            double price = 0;

            switch (laps)
            {
                case "five":
                    {
                        switch (typeKart)
                        {
                            case "Child":
                                {
                                    price = 7;
                                    break;
                                }
                            case "Junior":
                                {
                                    price = 9;
                                    break;
                                }
                            case "Adult":
                                {
                                    price = 12;
                                    break;
                                }
                            case "Profi":
                                {
                                    price = 18;
                                    break;
                                }
                        }
                        break;
                    }
                case "ten":
                    {
                        switch (typeKart)
                        {
                            case "Child":
                                {
                                    price = 11;
                                    break;
                                }
                            case "Junior":
                                {
                                    price = 16;
                                    break;
                                }
                            case "Adult":
                                {
                                    price = 21;
                                    break;
                                }
                            case "Profi":
                                {
                                    price = 32;
                                    break;
                                }
                        }
                        break;
                    }
            }
            if(fanCard == "yes")
            {
                price = price * 0.80;
            }
            if(sum >= price)
            {
                Console.WriteLine($"You bought {typeKart} ticket for {laps} laps. Your change is {sum-price:f2}lv.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need {price-sum:f2}lv more.");
            }
        }
    }
}
