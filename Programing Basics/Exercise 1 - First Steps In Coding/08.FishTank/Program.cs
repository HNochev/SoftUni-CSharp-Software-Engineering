using System;

namespace _08.FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double notAvailablePercent = double.Parse(Console.ReadLine());

            int volume = lenght * width * height;
            double liters = volume * 0.001;
            double finalLiters = liters - (liters * (notAvailablePercent / 100));

            Console.WriteLine(finalLiters);
        }
    }
}
