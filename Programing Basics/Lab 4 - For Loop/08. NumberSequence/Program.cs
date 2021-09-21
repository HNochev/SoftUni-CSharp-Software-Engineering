using System;

namespace _08._NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int max = int.MinValue;


            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if(number < min)
                {
                    min = number;
                }
                if(number>max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
