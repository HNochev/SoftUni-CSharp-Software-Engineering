using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int sumTime = firstTime + secondTime + thirdTime;

            int hours = sumTime / 60;
            int minutes = sumTime % 60;

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
