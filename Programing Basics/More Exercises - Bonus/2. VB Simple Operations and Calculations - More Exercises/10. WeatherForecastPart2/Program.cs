using System;

namespace _10._WeatherForecastPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            double degree = double.Parse(Console.ReadLine());

            if(degree >= 26 && degree <= 35)
            {
                Console.WriteLine("Hot");
            }
            else if(degree > 20 && degree < 26)
            {
                Console.WriteLine("Warm");
            }
            else if (degree >= 15 && degree <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (degree >= 12 && degree < 15)
            {
                Console.WriteLine("Cool");
            }
            else if (degree >= 5 && degree < 12)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
