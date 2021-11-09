using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int primarySum = 0;
            int secondarySum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        primarySum = primarySum + matrix[row, col];
                    }
                    if (col == n - 1 - row)
                    {
                        secondarySum = secondarySum + matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
