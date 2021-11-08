using System;
using System.Diagnostics.CodeAnalysis;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascal = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                pascal[row] = new long[row + 1];
                for (int col = 0; col < row +1; col++)
                {
                    if (row - 1 >= 0 && col >= 1 && col < pascal[row -1].Length)
                    {
                        pascal[row][col] = pascal[row][col] + pascal[row - 1][col];
                    }
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        pascal[row][col] = pascal[row][col] + pascal[row - 1][col - 1];
                    }
                    if (pascal[row][col] == 0)
                    {
                        pascal[row][col] = 1;
                    }
                }
            }

            for (int i = 0; i < pascal.Length; i++)
            {
                for (int j = 0; j < pascal[i].Length; j++)
                {
                    Console.Write($"{pascal[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
