using System;
using System.Linq;
using System.Numerics;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberRotations = int.Parse(Console.ReadLine());

            int[] temp = new int[array.Length];
            int firstElement = 0;

            for (int i = 0; i < numberRotations; i++)
            {
                firstElement = array[0];
                for (int j = 1; j < temp.Length; j++)
                {
                    temp[j - 1] = array[j];
                }
                temp[temp.Length - 1] = firstElement;
                array = temp;
            }
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
