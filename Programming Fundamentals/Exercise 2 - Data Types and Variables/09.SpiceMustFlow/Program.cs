using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int sum = 0;

            while(startingYield >= 100)
            {
                sum = sum + (startingYield-26);
                startingYield = startingYield - 10;
                if(startingYield<100)
                {
                    sum = sum - 26;
                }
                days++;
            }
            Console.WriteLine(days);
            Console.WriteLine(sum);
        }
    }
}
