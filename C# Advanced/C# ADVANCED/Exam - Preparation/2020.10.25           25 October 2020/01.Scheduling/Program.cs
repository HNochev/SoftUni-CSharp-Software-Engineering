using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                int task = tasks.Pop();
                int thread = threads.Dequeue();

                if (task == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToBeKilled}");
                    Console.Write($"{thread} ");
                    break;
                }
                if (thread < task)
                {
                    tasks.Push(task);
                }
            }
            Console.Write(string.Join(" ", threads));

        }
    }
}
