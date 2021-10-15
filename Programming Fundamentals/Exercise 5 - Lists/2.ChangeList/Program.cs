using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);


            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "DELETE":
                        {
                            numbers = numbers.Where(n => n != int.Parse(command[1])).ToList();
                            break;
                        }
                    case "INSERT":
                        {
                            numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                            break;
                        }
                }
                command = Console.ReadLine().ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
