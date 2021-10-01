using System;

namespace _07._FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            double fans = double.Parse(Console.ReadLine());
            double a = 0;
            double b = 0;
            double v = 0;
            double g = 0;

            for (int i = 0; i < fans; i++)
            {
                string sector = Console.ReadLine();
                if (sector == "A")
                {
                    a++;
                }
                else if (sector == "B")
                {
                    b++;
                }
                else if (sector == "V")
                {
                    v++;
                }
                else if (sector == "G")
                {
                    g++;
                }
            }
            Console.WriteLine($"{a / fans * 100:f2}%");
            Console.WriteLine($"{b / fans * 100:f2}%");
            Console.WriteLine($"{v / fans * 100:f2}%");
            Console.WriteLine($"{g / fans * 100:f2}%");
            Console.WriteLine($"{fans / capacity * 100:f2}%");
        }
    }
}
