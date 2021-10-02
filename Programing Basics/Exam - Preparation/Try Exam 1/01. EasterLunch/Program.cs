using System;

namespace _01._EasterLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunaks = int.Parse(Console.ReadLine());
            int cardOfEggs = int.Parse(Console.ReadLine());
            int kgKurabii = int.Parse(Console.ReadLine());

            int eggs = cardOfEggs * 12;

            double priceKozunaks = kozunaks * 3.20;
            double priceCardOfEggs = cardOfEggs * 4.35;
            double priceKurabii = kgKurabii * 5.40;
            double priceForPaint = eggs * 0.15;

            double finalPrice = priceCardOfEggs + priceForPaint + priceKozunaks + priceKurabii;

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
