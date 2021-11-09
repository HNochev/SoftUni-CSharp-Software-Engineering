using System;
using System.Linq;
using System.Numerics;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jagArray[row] = new double[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    jagArray[row][col] = input[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jagArray[row].Length == jagArray[row + 1].Length)
                {
                    for (int i = 0; i < jagArray[row].Length; i++)
                    {
                        jagArray[row][i] = jagArray[row][i] * 2;
                        jagArray[row + 1][i] = jagArray[row + 1][i] * 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jagArray[row].Length; i++)
                    {
                        jagArray[row][i] = jagArray[row][i] / 2;
                    }
                    for (int i = 0; i < jagArray[row + 1].Length; i++)
                    {
                        jagArray[row + 1][i] = jagArray[row + 1][i] / 2;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "End")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                double value = double.Parse(command[3]);

                if (row < 0 || col < 0 || row >= rows || col >= jagArray[row].Length)
                {
                    continue;
                }

                if (command[0] == "Add")
                {
                    jagArray[row][col] = jagArray[row][col] + value;
                }
                else if (command[0] == "Subtract")
                {
                    jagArray[row][col] = jagArray[row][col] - value;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", jagArray[i]));
            }
        }
    }
}
