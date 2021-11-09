using System;
using System.Linq;

namespace _5.SnakeMoves
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

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();
            int snakeCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[snakeCounter];
                        snakeCounter++;

                        if (snakeCounter == snake.Length)
                        {
                            snakeCounter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeCounter];
                        snakeCounter++;

                        if (snakeCounter == snake.Length)
                        {
                            snakeCounter = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
