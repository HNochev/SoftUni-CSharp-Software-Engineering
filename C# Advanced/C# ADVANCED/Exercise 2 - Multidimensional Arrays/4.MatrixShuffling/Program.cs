using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END")
                {
                    break;
                }
                if (command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowFirst = int.Parse(command[1]);
                int colFirst = int.Parse(command[2]);
                int rowSecond = int.Parse(command[3]);
                int colSecond = int.Parse(command[4]);

                if (command[0] != "swap" || rowFirst < 0 || colFirst < 0 || rowSecond < 0 || colSecond < 0 || rowFirst > matrix.GetLength(0) || colFirst > matrix.GetLength(0) || rowSecond > matrix.GetLength(0) || colSecond > matrix.GetLength(0))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string firstValue = matrix[rowFirst, colFirst];
                    string secondValue = matrix[rowSecond, colSecond];

                    matrix[rowSecond, colSecond] = firstValue;
                    matrix[rowFirst, colFirst] = secondValue;
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
}
