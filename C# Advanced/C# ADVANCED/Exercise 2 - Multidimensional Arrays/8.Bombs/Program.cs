using System;
using System.Data;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

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

            string[] bombsCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int bomb = 0; bomb < bombsCoordinates.Length; bomb++)
            {
                int[] rowCol = bombsCoordinates[bomb]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = rowCol[0];
                int col = rowCol[1];

                BombCells(row, col, matrix);
            }

            int aliveCells = 0;
            int theirSum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        theirSum = theirSum + matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {theirSum}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        private static void BombCells(int row, int col, int[,] matrix)
        {
            int damage = matrix[row, col];
            if (damage > 0)
            {
                BombOneCell(row - 1, col - 1, damage, matrix);
                BombOneCell(row - 1, col, damage, matrix);
                BombOneCell(row - 1, col + 1, damage, matrix);
                BombOneCell(row, col - 1, damage, matrix);
                BombOneCell(row, col + 1, damage, matrix);
                BombOneCell(row + 1, col - 1, damage, matrix);
                BombOneCell(row + 1, col, damage, matrix);
                BombOneCell(row + 1, col + 1, damage, matrix);
                matrix[row, col] = 0;
            }
        }
        private static void BombOneCell(int row, int col, int damage, int[,] matrix)
        {
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[row, col] > 0)
            {
                matrix[row, col] = matrix[row, col] - damage;
            }
        }
    }
}
