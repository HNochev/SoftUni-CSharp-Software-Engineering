using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sumOfAllRemoved = 0;

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                bool cantDelete = false;
                int indexValue = 0;

                if (index < 0)
                {

                    indexValue = numbers[0];
                    numbers[0] = numbers[numbers.Count - 1];
                    cantDelete = true;
                }
                else if (index > numbers.Count - 1)
                {
                    indexValue = numbers[numbers.Count - 1];
                    numbers[numbers.Count - 1] = numbers[0];
                    cantDelete = true;
                }


                if (!cantDelete)
                {
                    indexValue = numbers[index];
                    numbers.RemoveAt(index);
                }
                sumOfAllRemoved = sumOfAllRemoved + indexValue;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > indexValue)
                    {
                        numbers[i] = numbers[i] - indexValue;
                    }
                    else if (numbers[i] <= indexValue)
                    {
                        numbers[i] = numbers[i] + indexValue;
                    }
                }
            }
            Console.WriteLine(sumOfAllRemoved);
        }
    }
}
