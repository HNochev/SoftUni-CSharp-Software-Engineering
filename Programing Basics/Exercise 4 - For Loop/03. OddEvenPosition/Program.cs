using System;
using System.Transactions;

namespace _03._OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double evenMax = double.MinValue;
            double oddMax = double.MinValue;
            double evenMin = double.MaxValue;
            double oddMin = double.MaxValue;
            double evenSum = 0;
            double oddSum = 0;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                if(i%2==0)
                {
                    evenSum = evenSum + number;
                    if(number > evenMax)
                    {
                        evenMax = number;
                    }
                    if(number < evenMin)
                    {
                        evenMin = number;
                    }
                }
                else
                {
                    oddSum = oddSum + number;
                    if (number > oddMax)
                    {
                        oddMax = number;
                    }
                    if (number < oddMin)
                    {
                        oddMin = number;
                    }
                }
            }
            if (oddMin != double.MaxValue && oddMax != double.MinValue && evenMin != double.MaxValue && evenMax != double.MinValue) 
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            else if(oddMin == double.MaxValue && oddMax == double.MinValue && evenMax == double.MinValue && evenMin == double.MaxValue)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else if (oddMin != double.MaxValue && oddMax != double.MinValue && evenMax == double.MinValue && evenMin == double.MaxValue)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}
