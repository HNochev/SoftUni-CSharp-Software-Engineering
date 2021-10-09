using System;

namespace _07._WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            ushort sum = 0;

            for (byte i = 0; i < n; i++)
            {
                ushort liters = ushort.Parse(Console.ReadLine());

                if(sum + liters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                sum = (ushort)(sum + liters);
            }
            Console.WriteLine($"{sum}");
        }
    }
}
