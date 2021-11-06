using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numsStack = new Stack<int>(numbers);

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "end")
            {
                command[0] = command[0].ToLower();
                if (command[0] == "add")
                {
                    numsStack.Push(int.Parse(command[1]));
                    numsStack.Push(int.Parse(command[2]));
                }
                else if (command[0] == "remove")
                {
                    if (int.Parse(command[1]) <= numsStack.Count)
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            numsStack.Pop();
                        }
                    }
                }
                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Sum: {numsStack.Sum()}");
        }
    }
}
