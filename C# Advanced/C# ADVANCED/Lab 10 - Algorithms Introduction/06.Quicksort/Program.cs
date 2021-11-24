using System;
using System.Linq;

namespace _06.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            QuickSort.Sort(input, 0, input.Length - 1);

            Console.WriteLine(string.Join(" ", input));
        }
        public class QuickSort
        {
            public static int Partition(int[] array, int low, int high)
            {
                //1. Select a pivot point.
                int pivot = array[high];

                int lowIndex = (low - 1);

                //2. Reorder the collection.
                for (int j = low; j < high; j++)
                {
                    if (array[j] <= pivot)
                    {
                        lowIndex++;

                        int temp = array[lowIndex];
                        array[lowIndex] = array[j];
                        array[j] = temp;
                    }
                }

                int temp1 = array[lowIndex + 1];
                array[lowIndex + 1] = array[high];
                array[high] = temp1;

                return lowIndex + 1;
            }

            public static void Sort(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int partitionIndex = Partition(array, low, high);

                    //3. Recursively continue sorting the array
                    Sort(array, low, partitionIndex - 1);
                    Sort(array, partitionIndex + 1, high);
                }
            }
        }
    }
}

