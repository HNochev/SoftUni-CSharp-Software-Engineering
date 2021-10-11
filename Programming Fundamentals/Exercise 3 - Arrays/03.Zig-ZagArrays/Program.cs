using System;
using System.Linq;

namespace _03.Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array1 = new int[n];
            int[] array2 = new int[n];

            int position1 = 0;
            int position2 = 1;

            for (int i = 0; i < n; i++)
            {
                int[] inputs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();


                array1[i] = inputs[position1];
                array2[i] = inputs[position2];

                position1++;
                position2++;

                if (position1 == 2)
                {
                    position1 = 0;
                }
                if (position2 == 2)
                {
                    position2 = 0;
                }
            }
            Console.WriteLine(string.Join(' ', array1));
            Console.WriteLine(string.Join(' ', array2));
        }
    }
}
