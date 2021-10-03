using System;

namespace _01._Pool_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double priceShezlong = double.Parse(Console.ReadLine());
            double priceUmbrella = double.Parse(Console.ReadLine());

            double allShezlongs = people * 0.75;
            double allumbrellas = people * 0.50;

            double fullPrice = people * tax + Math.Ceiling(allShezlongs) * priceShezlong + Math.Ceiling(allumbrellas) * priceUmbrella;

            Console.WriteLine($"{fullPrice:f2} lv.");
        }
    }
}
