using System;

namespace _08.SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            string direction = "right";

            int row = 0;
            int col = 0;

            for (int i = 0; i < n*n; i++)
            {
                matrix[row, col] = i + 1;
                if(direction == "right")
                {
                    col++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "up")
                {
                    row--;
                }

                if((col == n || matrix[row,col] != 0) && direction == "right")
                {
                    col--;
                    row++;
                    direction = "down";
                }
                if ((row == n || matrix[row, col] != 0) && direction == "down")
                {
                    row--;
                    col--;
                    direction = "left";
                }
                if ((col == -1 || matrix[row, col] != 0) && direction == "left")
                {
                    col++;
                    row--;
                    direction = "up";
                }
                if ((row == -1 || matrix[row, col] != 0) && direction == "up")
                {
                    row++;
                    col++;
                    direction = "right";
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
