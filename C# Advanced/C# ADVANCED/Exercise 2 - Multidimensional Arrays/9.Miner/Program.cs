using System;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[n, n];

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = input[col];
                    if (input[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }


            foreach (string command in commands)
            {
                char element = '0';
                if (command == "left")
                {
                    if (startCol - 1 >= 0)
                    {
                        element = field[startRow, startCol - 1];

                        startCol = startCol - 1;
                    }
                }
                else if (command == "up")
                {
                    if (startRow - 1 >= 0)
                    {
                        element = field[startRow - 1, startCol];

                        startRow = startRow - 1;
                    }
                }
                else if (command == "right")
                {
                    if (startCol + 1 < field.GetLength(1))
                    {
                        element = field[startRow, startCol + 1];

                        startCol = startCol + 1;
                    }
                }
                else if (command == "down")
                {
                    if (startRow + 1 < field.GetLength(0))
                    {
                        element = field[startRow + 1, startCol];

                        startRow = startRow + 1;
                    }
                }
                if (element == '*')
                {
                    continue;
                }
                if (element == 'c')
                {
                    field[startRow, startCol] = '*';
                }
                if (element == 'e')
                {
                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                    return;
                }
            }
            int coalsCount = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (field[i, j] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }
            if (coalsCount == 0)
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
            else
            {
                Console.WriteLine($"{coalsCount} coals left. ({startRow}, {startCol})");
            }
        }
    }
}
