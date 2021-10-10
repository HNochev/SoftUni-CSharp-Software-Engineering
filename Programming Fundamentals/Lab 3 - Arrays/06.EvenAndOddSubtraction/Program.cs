using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;
            int oddSum = 0;
            int evenOddSubtraction = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if(number[i]%2==0)
                {
                    evenSum = evenSum + number[i];
                }
                else
                {
                    oddSum = oddSum + number[i];
                }
            }
            evenOddSubtraction = evenSum - oddSum;


            Console.WriteLine($"{evenOddSubtraction}");
        }
    }
}
