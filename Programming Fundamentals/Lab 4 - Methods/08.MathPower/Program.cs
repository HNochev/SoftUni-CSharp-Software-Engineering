using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(NumberOnPower(number, power));
        }

        static double NumberOnPower(double num, double pow)
        {
            double result = num;

            for (int i = 0; i < pow-1; i++)
            {
                result = result * num;
            }

            return result;
        }
    }
}
