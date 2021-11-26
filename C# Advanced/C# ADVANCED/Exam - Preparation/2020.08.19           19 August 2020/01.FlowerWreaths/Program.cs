using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int totalWreaths = 0;
            int leftSum = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();

                int sum = lili + rose;

                if (sum == 15)
                {
                    totalWreaths++;
                }
                else if (sum < 15)
                {
                    leftSum = leftSum + sum;
                }
                else
                {
                    if (sum % 2 == 0)
                    {
                        leftSum = leftSum + 14;
                    }
                    else
                    {
                        totalWreaths++;
                    }
                }
            }

            totalWreaths = totalWreaths + (leftSum / 15);

            if (totalWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {totalWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - totalWreaths} wreaths more!");
            }
        }
    }
}
