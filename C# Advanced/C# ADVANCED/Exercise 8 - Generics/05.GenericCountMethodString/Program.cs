using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
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

            string valueForComparisson = Console.ReadLine();

            Console.WriteLine(Compare(boxes, valueForComparisson));
        }

        public static int Compare<T>(List<Box<T>> list, T value)
            where T : IComparable
        {
            int count = 0;

            foreach (Box<T> box in list)
            {

                if (box.Value.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
