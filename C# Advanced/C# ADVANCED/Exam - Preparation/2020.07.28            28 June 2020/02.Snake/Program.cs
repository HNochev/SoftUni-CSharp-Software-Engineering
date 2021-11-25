using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int snakeRow = 0;
            int snakeCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int food = 0;
            string command = Console.ReadLine();

            while (food != 10)
            {
                matrix[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }

                if (snakeRow == n || snakeCol == n || snakeRow < 0 || snakeCol < 0)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    food = food + 1;
                }

                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (matrix[i, j] == 'B')
                            {
                                snakeRow = i;
                                snakeCol = j;
                            }
                        }
                    }
                }

                matrix[snakeRow, snakeCol] = 'S';
                command = Console.ReadLine();
            }

            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {food}");



            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
