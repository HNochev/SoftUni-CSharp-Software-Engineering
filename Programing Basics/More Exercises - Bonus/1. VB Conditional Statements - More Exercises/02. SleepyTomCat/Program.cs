using System;

namespace _02._SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int restingDays = int.Parse(Console.ReadLine());

            int playingWorkingDays = (365 - restingDays) * 63;
            int playingRestingDays = restingDays * 127;

            int finalPlaying = playingRestingDays + playingWorkingDays;

            int hours = Math.Abs(finalPlaying-30000)/60;
            int mins = Math.Abs(finalPlaying - 30000) %60;

            if(finalPlaying>30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {mins} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {mins} minutes less for play");
            }

        }
    }
}
