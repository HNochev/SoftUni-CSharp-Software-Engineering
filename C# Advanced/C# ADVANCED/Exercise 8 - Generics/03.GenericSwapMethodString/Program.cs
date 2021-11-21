using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());

                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(boxes, indexes[0], indexes[1]);

            foreach (Box<string> box in boxes)
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
