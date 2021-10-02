using System;
using System.Runtime.InteropServices.ComTypes;

namespace _05._EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            double allEggs = double.Parse(Console.ReadLine());
            int redcounter = 0;
            int orangecounter = 0;
            int bluecounter = 0;
            int greencounter = 0;

            int maxEggs = 0;
            string maxColor = "";

            for (int i = 1; i <= allEggs; i++)
            {
                string color = Console.ReadLine();
                switch (color)
                {
                    case "red":
                        {
                            redcounter++;
                            break;
                        }
                    case "orange":
                        {
                            orangecounter++;
                            break;
                        }
                    case "blue":
                        {
                            bluecounter++;
                            break;
                        }
                    case "green":
                        {
                            greencounter++;
                            break;
                        }
                }
            }
            if(greencounter >= redcounter && greencounter >= orangecounter && greencounter >= bluecounter)
            {
                maxEggs = greencounter;
                maxColor = "green";
            }
            else if(bluecounter >= redcounter && bluecounter >= orangecounter && bluecounter >= greencounter)
            {
                maxEggs = bluecounter;
                maxColor = "blue";
            }
            else if (orangecounter >= redcounter && orangecounter >= bluecounter && orangecounter >= greencounter)
            {
                maxEggs = orangecounter;
                maxColor = "orange";
            }
            else if (redcounter >= orangecounter && redcounter >= bluecounter && redcounter >= greencounter)
            {
                maxEggs = redcounter;
                maxColor = "red";
            }
            Console.WriteLine($"Red eggs: {redcounter}");
            Console.WriteLine($"Orange eggs: {orangecounter}");
            Console.WriteLine($"Blue eggs: {bluecounter}");
            Console.WriteLine($"Green eggs: {greencounter}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxColor}");
        }
    }
}
