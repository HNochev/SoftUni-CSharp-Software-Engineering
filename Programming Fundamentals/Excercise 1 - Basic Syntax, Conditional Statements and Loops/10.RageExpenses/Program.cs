using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsets = lostGames / 2;
            int mouses = lostGames / 3;
            int keyboards = lostGames / 6;
            int displays = lostGames / 12;

            double finalPrice = (headsetPrice * headsets) + (mousePrice * mouses) + (keyboardPrice * keyboards) + (displayPrice * displays);

            Console.WriteLine($"Rage expenses: {finalPrice:f2} lv.");
        }
    }
}
