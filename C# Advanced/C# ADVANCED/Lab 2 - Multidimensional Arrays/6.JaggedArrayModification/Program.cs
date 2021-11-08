using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string[] command = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if(command[0] == "Add" && row < matrix.GetLength(0) && col < matrix.GetLength(1) && row >= 0 && col >= 0)
                {
                    matrix[row, col] = matrix[row, col] + value;
                }
                else if(command[0] == "Subtract" && row < matrix.GetLength(0) && col < matrix.GetLength(1) && row >= 0 && col >= 0)
                {
                    matrix[row, col] = matrix[row, col] - value;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
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
