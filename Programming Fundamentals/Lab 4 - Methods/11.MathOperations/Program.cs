using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double second = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(first, second, symbol));
        }

        static double Calculate(double a, double b, string action)
        {
            double result = 0;
            switch (action)
            {
                case "/":
                    {
                        result = a / b;
                        break;
                    }
                case "*":
                    {
                        result = a * b;
                        break;
                    }
                case "+":
                    {
                        result = a + b;
                        break;
                    }
                case "-":
                    {
                        result = a - b;
                        break;
                    }
            }
            return result;
        }
    }
}
