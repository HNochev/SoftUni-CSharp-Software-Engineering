using System;

namespace _08._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int others = int.Parse(Console.ReadLine());

            double finalPrice = dogs * 2.5 + others * 4;

            Console.WriteLine($"{finalPrice} lv.");
        }
    }
}
