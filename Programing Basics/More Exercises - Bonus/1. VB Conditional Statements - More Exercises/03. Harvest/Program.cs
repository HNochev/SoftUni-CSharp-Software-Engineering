using System;

namespace _03._Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapeForOneSquareMeter = double.Parse(Console.ReadLine());
            int neededLiters = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double finalGrape = area * grapeForOneSquareMeter;
            double finalwine = finalGrape / 2.5 * 0.40;

            if (finalwine < neededLiters)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededLiters - finalwine)} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(finalwine)} liters.");
                Console.WriteLine($"{Math.Ceiling(finalwine - neededLiters)} liters left -> {Math.Ceiling((finalwine - neededLiters) / workers)} liters per person.");
            }
        }
    }
}
