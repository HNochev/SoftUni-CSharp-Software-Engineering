using System;

namespace _02._MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSec = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double hisTimeForMeter = double.Parse(Console.ReadLine());

            double hisTime = hisTimeForMeter * meters;
            double delay = Math.Floor(meters / 50.0) * 30.0;

            double finalTime = hisTime + delay;

            if(finalTime<recordSec)
            {
                Console.WriteLine($"Yes! The new record is {finalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(recordSec-finalTime):f2} seconds slower.");
            }
        }
    }
}
