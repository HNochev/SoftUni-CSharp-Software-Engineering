using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(MinNum(arr));
        }
        static int MinNum(int[] array)
        {
            int minNum = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] < minNum)
                {
                    minNum = array[i];
                }
            }
            return minNum;
        }
    }
}
