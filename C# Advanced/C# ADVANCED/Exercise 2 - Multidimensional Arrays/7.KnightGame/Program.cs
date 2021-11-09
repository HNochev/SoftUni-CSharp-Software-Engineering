using System;
using System.Data;
using System.Linq;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    chessBoard[row, col] = input[col];
                }
            }

            int removedKnightsCount = 0;

            while (true)
            {
                int maxAttackedKnightsCount = 0;
                int maxRow = 0;
                int maxCol = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char symbol = chessBoard[row, col];
                        int count = 0;
                        if (symbol == 'K')
                        {

                            count = GetCountOfAttackedKnights(chessBoard, row, col);

                            if (count > maxAttackedKnightsCount)
                            {
                                maxAttackedKnightsCount = count;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
                if (maxAttackedKnightsCount > 0)
                {
                    chessBoard[maxRow, maxCol] = '0';
                    removedKnightsCount++;
                }
                else
                {
                    Console.WriteLine(removedKnightsCount);
                    break;
                }
            }
        }

        private static int GetCountOfAttackedKnights(char[,] chessBoard, int row, int col)
        {
            int count = 0;

            if (IsInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
            {
                count++;
            }
            if (IsInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
            {
                count++;
            }
            if (IsInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
            {
                count++;
            }
            if (IsInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
            {
                count++;
            }
            if (IsInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
            {
                count++;
            }
            if (IsInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
            {
                count++;
            }
            if (IsInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
            {
                count++;
            }
            if (IsInside(chessBoard, row + 2, col +1) && chessBoard[row + 2, col +1] == 'K')
            {
                count++;
            }
            return count;
        }

        private static bool IsInside(char[,] chessBoard, int row, int col)
        {
            return row >= 0 && row < chessBoard.GetLength(0)
                && col >= 0 && col < chessBoard.GetLength(1);
        }
    }
}
