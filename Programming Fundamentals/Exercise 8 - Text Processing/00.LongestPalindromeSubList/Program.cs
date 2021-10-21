using System;

namespace _00.LongestPalindromeSubList
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();

            int maxLen = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                maxLen = Math.Max(maxLen, PalindromeLen(letters, i, i));
            }

            for (int i = 0; i < letters.Length - 1; i++)
            {
                maxLen = Math.Max(maxLen, PalindromeLen(letters, i, i + 1));
            }

            Console.WriteLine(maxLen);
        }
        static int PalindromeLen(string letters, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < letters.Length && letters[leftIndex] == letters[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }
            return rightIndex - leftIndex - 1;
        }
    }
}
