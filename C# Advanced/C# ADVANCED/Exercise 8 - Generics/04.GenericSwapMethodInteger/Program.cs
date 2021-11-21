using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));

                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(boxes, indexes[0], indexes[1]);

            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box);
            }
        }
        public static void Swap<T>(List<Box<T>> list, int firstIndex, int secondIndex)
        {
            Box<T> tempOne = new Box<T>(list[firstIndex].Value);
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tempOne;
        }
    }
}