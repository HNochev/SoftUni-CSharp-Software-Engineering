using System;
using System.Linq;

namespace _07.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int number = int.Parse(Console.ReadLine());

            Array.Sort(input);

            Console.WriteLine(BinarySearch.IndexOf(input, number));
        }
    }

    public class BinarySearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            int lo = 0;
            int hi = arr.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (key < arr[mid])
                {
                    hi = mid - 1;
                }
                else if (key > arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
