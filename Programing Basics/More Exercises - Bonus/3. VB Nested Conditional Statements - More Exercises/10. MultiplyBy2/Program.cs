using System;

namespace _10._MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            while (n >= 0)
            {
                Console.WriteLine($"Result: {n*2:f2}");
                n = double.Parse(Console.ReadLine());
            }
            if (n < 0)
            {
                Console.WriteLine("Negative number!");
            }
        }
    }
}
