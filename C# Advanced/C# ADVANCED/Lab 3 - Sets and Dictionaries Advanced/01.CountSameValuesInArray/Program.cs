using System;
using System.Collections.Generic;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> digits = new Dictionary<string, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if(!digits.ContainsKey(numbers[i]))
                {
                    digits.Add(numbers[i], 0);
                }
                digits[numbers[i]]++;
            }

            foreach (var item in digits)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
