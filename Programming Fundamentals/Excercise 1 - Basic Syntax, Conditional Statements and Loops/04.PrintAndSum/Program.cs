using System;

namespace _04.PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int finalNumber = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = startNumber; i <= finalNumber; i++)
            {
                Console.Write($"{i} ");
                sum = sum + i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
