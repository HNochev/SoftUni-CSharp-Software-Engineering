using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int result = 0;

            switch (action)
            {
                case "add":
                    {
                        result = Add(firstNumber, secondNumber);
                        break;
                    }
                case "multiply":
                    {
                        result = Multiply(firstNumber, secondNumber);
                        break;
                    }
                case "subtract":
                    {
                        result = Substract(firstNumber, secondNumber);
                        break;
                    }
                case "divide":
                    {
                        result = Divide(firstNumber, secondNumber);
                        break;
                    }
            }
            Console.WriteLine(result);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Substract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
