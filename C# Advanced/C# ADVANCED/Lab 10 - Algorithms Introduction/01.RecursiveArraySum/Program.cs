using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(array, array.Length));
        }

        public static int Sum(int[] array, int index)
        {
            if (index <= 0)
            {
                return 0;
            }
            return (Sum(array, index - 1) + array[index - 1]);
        }
    }
}
