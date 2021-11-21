using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));

                boxes.Add(box);
            }

            double valueForComparisson = double.Parse(Console.ReadLine());

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
