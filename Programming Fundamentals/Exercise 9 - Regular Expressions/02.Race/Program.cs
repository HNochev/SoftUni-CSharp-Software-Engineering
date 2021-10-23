using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();

            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var item in names)
            {
                racers.Add(item, 0);
            }

            string namePattern = @"[^A-Za-z]";
            string pointsPattern = @"[^0-9]";


            Regex pointsRegex = new Regex(pointsPattern);

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                //1ви начин
                string name = Regex.Replace(input, namePattern, "");
                //2ри начин
                string points = pointsRegex.Replace(input, "");

                int allPoints = 0;

                if (racers.ContainsKey(name))
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        allPoints = allPoints + int.Parse(points[i].ToString());
                    }

                    racers[name] = racers[name] + allPoints;
                }

                input = Console.ReadLine();
            }
            int counter = 1;
            foreach (var racer in racers.OrderByDescending(x => x.Value))
            {
                string text = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";

                Console.WriteLine($"{counter}{text} place: {racer.Key}");
                counter++;

                if(counter == 4)
                {
                    break;
                }
            }
        }
    }
}
