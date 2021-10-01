using System;

namespace _10._ClockPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hour = 0; hour < 24; hour++)
            {
                for (int minutes = 0; minutes < 60; minutes++)
                {
                    for (int seconds = 0; seconds < 60; seconds++)
                    {
                        Console.WriteLine($"{hour} : {minutes} : {seconds}");
                    }
                }
            }
        }
    }
}
