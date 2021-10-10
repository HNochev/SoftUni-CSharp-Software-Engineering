using System;
using System.Linq;

namespace _02._PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int[] newArr = arr.Reverse().ToArray();

            Console.WriteLine(string.Join(' ', arr.Reverse()));
        }
    }
}
