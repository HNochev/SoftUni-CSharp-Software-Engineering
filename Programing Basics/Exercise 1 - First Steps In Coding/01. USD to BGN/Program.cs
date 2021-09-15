using System;

namespace _01._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usdToBgnCourse = 1.79549;
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * usdToBgnCourse;
            Console.WriteLine(bgn);
        }
    }
}
