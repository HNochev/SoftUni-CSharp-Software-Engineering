using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowCol[0];
            int cols = rowCol[1];

            int[,] matrix = new int[rows, cols];

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                int[] coordinatesRowCol = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinatesRowCol[0];
                int col = coordinatesRowCol[1];

                if (row >= rows || col >= cols || row < 0 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                    continue;
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (i == row)
                        {
                            matrix[i, j]++;
                        }
                        if (j == col && j != i)
                        {
                            matrix[i, j]++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
