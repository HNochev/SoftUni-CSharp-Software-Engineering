using System;

namespace _05._DivisionWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double two = 0;
            double three = 0;
            double four = 0;

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    two++;
                }
                if (number % 3 == 0)
                {
                    three++;
                }
                if (number % 4 == 0)
                {
                    four++;
                }
            }
            Console.WriteLine($"{two/n*100:f2}%");
            Console.WriteLine($"{three/n*100:f2}%");
            Console.WriteLine($"{four/n*100:f2}%");
        }
    }
}
