using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int lines = int.Parse(Console.ReadLine());
            int coloums = int.Parse(Console.ReadLine());
            double finalMoney = 0.0;

            switch (type)
            {
                case "Premiere":
                    {
                        finalMoney = 12.00 * (lines * coloums);
                        break;
                    }
                case "Normal":
                    {
                        finalMoney = 7.50 * (lines * coloums);
                        break;
                    }
                case "Discount":
                    {
                        finalMoney = 5.00 * (lines * coloums);
                        break;
                    }
            }
            Console.WriteLine($"{finalMoney:f2} leva");
        }
    }
}
