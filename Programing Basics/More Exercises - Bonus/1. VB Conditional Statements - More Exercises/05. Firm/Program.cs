using System;

namespace _05._Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int overworkingWorkers = int.Parse(Console.ReadLine());

            double theirHours = days * 8 * 0.90;
            double overworkHours = days * 2 * overworkingWorkers;

            double finalhours = theirHours + overworkHours;

            if(finalhours >= neededHours)
            {
                Console.WriteLine($"Yes!{Math.Floor(finalhours - neededHours)} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Ceiling(neededHours - finalhours)} hours needed.");
            }

        }
    }
}
