using System;
using System.Transactions;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());

            double fullTime = distance * timeForOneMeter;
            double delayTime = Math.Floor(distance / 15) * 12.5;
            double finalTime = fullTime + delayTime;

            if(finalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:f2} seconds.");
            }
            else
            {
                double neededSeconds = finalTime - record;
                Console.WriteLine($"No, he failed! He was {neededSeconds:f2} seconds slower.");
            }
        }
    }
}
