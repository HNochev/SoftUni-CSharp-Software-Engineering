using System;

namespace _11.MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int fromNumber = int.Parse(Console.ReadLine());
            int multiply = 0;

            for (; fromNumber <= 9; fromNumber++)
            {
                multiply = number * fromNumber;
                Console.WriteLine($"{number} X {fromNumber} = {multiply}");
                multiply = 0;
            }
            if(fromNumber>=10)
            {
                multiply = number * fromNumber;
                Console.WriteLine($"{number} X {fromNumber} = {multiply}");
            }
        }
    }
}
