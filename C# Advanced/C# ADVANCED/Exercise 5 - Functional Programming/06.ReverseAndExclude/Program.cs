using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());


            numbers.Reverse();

            Func<int, int, bool> filter = (num, divider) => num % divider != 0;

            numbers = numbers.Where(number => filter(number, n)).ToList();

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            print(numbers);
        }
    }
}
