using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong numberForFactorial = ulong.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(numberForFactorial));
        }

        public static ulong Factorial(ulong number)
        {
            if (number == 0)

            {

                return 1;

            }

            return number * Factorial(number - 1);
        }
    }
}
