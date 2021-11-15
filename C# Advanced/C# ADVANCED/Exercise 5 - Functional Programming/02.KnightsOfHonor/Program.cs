using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] newNames = names
                .Select(name => $"Sir {name}")
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, newNames));
        }
    }
}
