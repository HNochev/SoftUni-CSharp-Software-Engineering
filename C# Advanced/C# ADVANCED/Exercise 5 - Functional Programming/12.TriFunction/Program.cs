using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int> getAskiiSum = p => p.Select(ch => (int)ch).Sum();

            //string person = GetName(names, n, getAskiiSum);
            //Console.WriteLine(person);

            Func<List<string>, int, Func<string, int>, string> nameFunc = (people, n, func) => people.FirstOrDefault(p => func(p) >= n);

            string result = nameFunc(names, n, getAskiiSum);
            Console.WriteLine(result);
        }

        static string GetName(List<string> people, int n, Func<string, int> predicate)
        {
            string result = null;

            foreach (string person in people)
            {
                if (predicate(person) >= n)
                {
                    result = person;
                }
            }
            return result;
        }
    }
}
