using System;
using System.Collections.Generic;
using System.Linq;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attacks = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int playerOneShips = 0;
            int playerTwoShips = 0;
            int totoalDestroyedShips = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }




            for (int i = 0; i < attacks.Count; i++)
            {
                int[] rowCol = attacks[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = rowCol[0];
                int col = rowCol[1];

                if (row >= n || col >= n || row < 0 || col < 0)
                {
                    continue;
                }
                else
                {
                    if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        playerOneShips--;
                        totoalDestroyedShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        playerTwoShips--;
                        totoalDestroyedShips++;
                    }
                    else if (matrix[row, col] == '#')
                    {
                        if (row - 1 < n && col - 1 < n && row - 1 >= 0 && col - 1 >= 0)
                        {
                            if (matrix[row - 1, col - 1] == '>')
                            {
                                matrix[row - 1, col - 1] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row - 1, col - 1] == '<')
                            {
                                matrix[row - 1, col - 1] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                        if (row - 1 < n && col < n && row - 1 >= 0 && col >= 0)
                        {
                            if (matrix[row - 1, col] == '>')
                            {
                                matrix[row - 1, col] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row - 1, col] == '<')
                            {
                                matrix[row - 1, col] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                        if (row - 1 < n && col + 1 < n && row - 1 >= 0 && col + 1 >= 0)
                        {
                            if (matrix[row - 1, col + 1] == '>')
                            {
                                matrix[row - 1, col + 1] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row - 1, col + 1] == '<')
                            {
                                matrix[row - 1, col + 1] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                        if (row < n && col - 1 < n && row >= 0 && col - 1 >= 0)
                        {
                            if (matrix[row, col - 1] == '>')
                            {
                                matrix[row, col - 1] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row, col - 1] == '<')
                            {
                                matrix[row, col - 1] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                        if (row < n && col + 1 < n && row >= 0 && col + 1 >= 0)
                        {
                            if (matrix[row, col + 1] == '>')
                            {
                                matrix[row, col + 1] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row, col + 1] == '<')
                            {
                                matrix[row, col + 1] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                        if (row + 1 < n && col - 1 < n && row + 1 >= 0 && col - 1 >= 0)
                        {
                            if (matrix[row + 1, col - 1] == '>')
                            {
                                matrix[row + 1, col - 1] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row + 1, col - 1] == '<')
                            {
                                matrix[row + 1, col - 1] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                        if (row + 1 < n && col < n && row + 1 >= 0 && col >= 0)
                        {
                            if (matrix[row + 1, col] == '>')
                            {
                                matrix[row + 1, col] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row + 1, col] == '<')
                            {
                                matrix[row + 1, col] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                        if (row + 1 < n && col + 1 < n && row + 1 >= 0 && col + 1 >= 0)
                        {
                            if (matrix[row + 1, col + 1] == '>')
                            {
                                matrix[row + 1, col + 1] = 'X';
                                playerTwoShips--;
                                totoalDestroyedShips++;
                            }
                            else if (matrix[row + 1, col + 1] == '<')
                            {
                                matrix[row + 1, col + 1] = 'X';
                                playerOneShips--;
                                totoalDestroyedShips++;
                            }
                        }
                    }
                }
            }

            if (playerOneShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totoalDestroyedShips} ships have been sunk in the battle.");
            }
            else if (playerTwoShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {totoalDestroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }



        }
    }
}
