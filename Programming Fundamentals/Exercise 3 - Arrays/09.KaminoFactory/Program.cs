using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNALength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int bestLenght = 1;
            int bestStartIndex = 0;
            int bestSequenceSum = 0;
            int sequenceCounter = 0;
            int bestSequenceConter = 1;
            int[] bestArray = new int[DNALength];


            while (input != "Clone them!")
            {
                int[] array = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sequenceCounter++;

                int lenght = 1;
                int bestCurrentLenght = 1;
                int start = 0;
                int currentSequenceSum = 0;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] == array[i + 1])
                    {
                        lenght++;
                    }
                    else
                    {
                        lenght = 1;
                    }

                    if (lenght > bestCurrentLenght)
                    {
                        bestCurrentLenght = lenght;
                        start = i;
                    }
                    currentSequenceSum = currentSequenceSum + array[i];
                }
                currentSequenceSum = currentSequenceSum + array[DNALength-1];

                if (bestCurrentLenght > bestLenght)
                {
                    bestLenght = bestCurrentLenght;
                    bestStartIndex = start;
                    bestSequenceSum = currentSequenceSum;
                    bestSequenceConter = sequenceCounter;
                    bestArray = array.ToArray();
                }
                else if (bestCurrentLenght == bestLenght)
                {
                    if (start < bestStartIndex)
                    {
                        bestLenght = bestCurrentLenght;
                        bestStartIndex = start;
                        bestSequenceSum = currentSequenceSum;
                        bestSequenceConter = sequenceCounter;
                        bestArray = array.ToArray();
                    }
                    else if (start == bestStartIndex)
                    {
                        if (currentSequenceSum > bestSequenceSum)
                        {
                            bestLenght = bestCurrentLenght;
                            bestStartIndex = start;
                            bestSequenceSum = currentSequenceSum;
                            bestSequenceConter = sequenceCounter;
                            bestArray = array.ToArray();
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSequenceConter} with sum: {bestSequenceSum}.");
            Console.WriteLine(String.Join(' ', bestArray));
        }
    }
}
