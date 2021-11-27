using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int startRow = 0;
            int startCol = 0;
            int money = 0;

            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            while (money < 50)
            {
                string command = Console.ReadLine();
                matrix[startRow, startCol] = '-';
                if (command == "up")
                {
                    startRow = startRow - 1;
                }
                else if (command == "down")
                {
                    startRow = startRow + 1;
                }
                else if (command == "left")
                {
                    startCol = startCol - 1;
                }
                else if (command == "right")
                {
                    startCol = startCol + 1;
                }

                if (startRow == n || startCol == n || startRow < 0 || startCol < 0)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write($"{matrix[i, j]}");
                        }
                        Console.WriteLine();
                    }
                    return;
                }

                if (matrix[startRow, startCol] == 'O')
                {
                    matrix[startRow, startCol] = '-';
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (matrix[i, j] == 'O')
                            {
                                startRow = i;
                                startCol = j;
                                matrix[startRow, startCol] = 'S';
                            }
                        }
                    }
                }

                if (Char.IsDigit(matrix[startRow, startCol]))
                {
                    int digit = int.Parse(matrix[startRow, startCol].ToString());
                    money = money + digit;
                }

                matrix[startRow, startCol] = 'S';
            }

            Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {money}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
