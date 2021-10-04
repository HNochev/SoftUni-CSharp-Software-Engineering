using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string yesNo = "";
            int days = 1;
            double climbing = 5364;

            while (true)
            {
                yesNo = Console.ReadLine();
                if (yesNo == "Yes")
                {
                    days++;
                }
                if (days > 5)
                {
                    Console.WriteLine($"Failed!");
                    Console.WriteLine($"{climbing}");
                    break;
                }
                if(yesNo == "END")
                {
                    Console.WriteLine($"Failed!");
                    Console.WriteLine($"{climbing}");
                    break;
                }
                double newMeters = double.Parse(Console.ReadLine());

                climbing = climbing + newMeters;
                if (climbing >= 8848)
                {
                    Console.WriteLine($"Goal reached for {days} days!");
                    break;
                }
            }
        }
    }
}
