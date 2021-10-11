using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] peopleInWagon = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                peopleInWagon[i] = int.Parse(Console.ReadLine());
                sum = sum + peopleInWagon[i];
            }

            Console.Write(string.Join(' ', peopleInWagon));

            Console.WriteLine("");
            Console.WriteLine($"{sum}");
        }
    }
}
