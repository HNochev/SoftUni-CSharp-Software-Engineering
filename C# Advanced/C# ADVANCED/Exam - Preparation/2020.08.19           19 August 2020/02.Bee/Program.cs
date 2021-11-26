using System;

namespace _02.Bee
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

            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            int flowers = 0;

            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';

                if (command == "up")
                {
                    beeRow--;
                }
                else if (command == "down")
                {
                    beeRow++;
                }
                else if (command == "left")
                {
                    beeCol--;
                }
                else if (command == "right")
                {
                    beeCol++;
                }

                if (beeRow == n || beeCol == n || beeRow < 0 || beeCol < 0)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';

                    if (command == "up")
                    {
                        beeRow--;
                    }
                    else if (command == "down")
                    {
                        beeRow++;
                    }
                    else if (command == "left")
                    {
                        beeCol--;
                    }
                    else if (command == "right")
                    {
                        beeCol++;
                    }

                    if (beeRow == n || beeCol == n || beeRow < 0 || beeCol < 0)
                    {
                        Console.WriteLine("The bee got lost!");
                        return;
                    }
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowers++;
                }

                matrix[beeRow, beeCol] = 'B';
                command = Console.ReadLine();
            }

            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }

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
