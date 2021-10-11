using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int stringLong = 1;
            int longestString = 0;
            int start = 0;
            int startOfLongestString = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == array[i])
                {
                    stringLong++;
                }
                else
                {
                    stringLong = 1;
                    start = i;
                }

                if (stringLong > longestString)
                {
                    longestString = stringLong;
                    startOfLongestString = start;
                }
            }
            for (int i = startOfLongestString; i < startOfLongestString+longestString; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
