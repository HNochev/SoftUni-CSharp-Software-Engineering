using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            Console.WriteLine(Substract(first, second, third));
        }

        static int Sum(int a, int b)
        {
            int result = a + b;
            return result;
        }

        static int Substract(int a, int b, int c)
        {
            int result = Sum(a,b) - c;
            return result;
        }
    }
}
