using System;

namespace _06._OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            double result = 0;
            string evenOdd = "";

            switch (symbol)
            {
                case '+':
                    {
                        result = n1 + n2;
                        if (result % 2 == 0)
                        {
                            evenOdd = "even";
                        }
                        else
                        {
                            evenOdd = "odd";
                        }

                        Console.WriteLine($"{n1} {symbol} {n2} = {result} - {evenOdd}");

                        break;
                    }
                case '-':
                    {
                        result = n1 - n2;
                        if (result % 2 == 0)
                        {
                            evenOdd = "even";
                        }
                        else
                        {
                            evenOdd = "odd";
                        }

                        Console.WriteLine($"{n1} {symbol} {n2} = {result} - {evenOdd}");

                        break;
                    }
                case '*':
                    {
                        result = n1 * n2;
                        if (result % 2 == 0)
                        {
                            evenOdd = "even";
                        }
                        else
                        {
                            evenOdd = "odd";
                        }

                        Console.WriteLine($"{n1} {symbol} {n2} = {result} - {evenOdd}");

                        break;
                    }
                case '/':
                    {
                        result = n1 / n2;
                        if (n2 == 0)
                        {
                            Console.WriteLine($"Cannot divide {n1} by zero");
                        }
                        else
                        {
                            Console.WriteLine($"{n1} / {n2} = {result:f2}");
                        }
                        break;
                    }
                case '%':
                    {
                        result = n1 % n2;
                        if (n2 == 0)
                        {
                            Console.WriteLine($"Cannot divide {n1} by zero");
                        }
                        else
                        {
                            Console.WriteLine($"{n1} % {n2} = {result}");
                        }
                        break;
                    }
            }
        }
    }
}
