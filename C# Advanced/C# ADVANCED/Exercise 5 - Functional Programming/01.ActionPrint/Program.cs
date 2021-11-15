using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> namePrint = x => Console.WriteLine(x);

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                namePrint(name);
            }
        }
    }
}
