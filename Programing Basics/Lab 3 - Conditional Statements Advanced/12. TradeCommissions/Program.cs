using System;

namespace _12._TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double money = double.Parse(Console.ReadLine());
            double comission = 0;

            switch (town)
            {
                case "Sofia":
                    {
                        if(money >= 0 && money <= 500)
                        {
                            comission = money * 0.05;
                            Console.WriteLine($"{comission:f2}");

                        }
                        else if (money > 500 && money <= 1000)
                        {
                            comission = money * 0.07;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else if (money > 1000 && money <= 10000)
                        {
                            comission = money * 0.08;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else if (money >10000)
                        {
                            comission = money * 0.12;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    }
                case "Plovdiv":
                    {
                        if (money >= 0 && money <= 500)
                        {
                            comission = money * 0.055;
                            Console.WriteLine($"{comission:f2}");

                        }
                        else if (money > 500 && money <= 1000)
                        {
                            comission = money * 0.08;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else if (money > 1000 && money <= 10000)
                        {
                            comission = money * 0.12;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else if (money > 10000)
                        {
                            comission = money * 0.145;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    }
                case "Varna":
                    {
                        if (money >= 0 && money <= 500)
                        {
                            comission = money * 0.045;
                            Console.WriteLine($"{comission:f2}");

                        }
                        else if (money > 500 && money <= 1000)
                        {
                            comission = money * 0.075;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else if (money > 1000 && money <= 10000)
                        {
                            comission = money * 0.10;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else if (money > 10000)
                        {
                            comission = money * 0.13;
                            Console.WriteLine($"{comission:f2}");
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("error");
                        break;
                    }
            }
            
        }
    }
}
