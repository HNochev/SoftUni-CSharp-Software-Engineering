using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, int, bool> nameFilter = (name, lenght) => name.Length <= lenght;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(name => nameFilter(name, n))));
        }
    }
}
