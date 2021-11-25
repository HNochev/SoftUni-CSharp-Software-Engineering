using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            for (int i = 0; i < countCommands; i++)
            {
                string command = Console.ReadLine();
                matrix[currRow, currCol] = '-';

                int lastRow = currRow;
                int lastCol = currCol;

                if (command == "up")
                {
                    currRow--;
                }
                else if (command == "down")
                {
                    currRow++;
                }
                else if (command == "left")
                {
                    currCol--;
                }
                else if (command == "right")
                {
                    currCol++;
                }


                if (currRow == n)
                {
                    currRow = 0;
                }
                else if (currCol == n)
                {
                    currCol = 0;
                }
                else if (currRow < 0)
                {
                    currRow = n - 1;
                }
                else if (currCol < 0)
                {
                    currCol = n - 1;
                }

                if (matrix[currRow, currCol] == 'B')
                {
                    lastRow = currRow;
                    lastCol = currCol;

                    if (command == "up")
                    {
                        currRow--;
                    }
                    else if (command == "down")
                    {
                        currRow++;
                    }
                    else if (command == "left")
                    {
                        currCol--;
                    }
                    else if (command == "right")
                    {
                        currCol++;
                    }


                    if (currRow == n)
                    {
                        currRow = 0;
                    }
                    else if (currCol == n)
                    {
                        currCol = 0;
                    }
                    else if (currRow < 0)
                    {
                        currRow = n - 1;
                    }
                    else if (currCol < 0)
                    {
                        currCol = n - 1;
                    }
                }

                if (matrix[currRow, currCol] == 'T')
                {
                    currRow = lastRow;
                    currCol = lastCol;
                }

                if (matrix[currRow, currCol] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[currRow, currCol] = 'f';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }

                    return;
                }
                matrix[currRow, currCol] = 'f';
            }

            Console.WriteLine($"Player lost!");



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
