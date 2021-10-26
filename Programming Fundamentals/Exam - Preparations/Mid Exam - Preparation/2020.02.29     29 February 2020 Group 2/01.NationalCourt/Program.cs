using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            byte firstE = byte.Parse(Console.ReadLine());
            byte secondE = byte.Parse(Console.ReadLine());
            byte thirdE = byte.Parse(Console.ReadLine());

            int allEWork = firstE + secondE + thirdE;

            int allPeople = int.Parse(Console.ReadLine());
            int hours = 0;

            while (allPeople != 0)
            {
                if (hours % 4 == 0 && hours != 0)
                {
                    hours++;
                    continue;
                }

                if (allPeople >= allEWork)
                {
                    allPeople = allPeople - allEWork;
                    hours++;
                }
                else if (allPeople < allEWork)
                {
                    allPeople = allPeople - allPeople;
                    hours++;
                }
            }
            if (hours % 4 == 0 && hours != 0)
            {
                hours++;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
