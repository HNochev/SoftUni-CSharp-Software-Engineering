using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string command = Console.ReadLine();

            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Any())
            {
                if (command == "Play")
                {
                    if (songsQueue.Any())
                    {
                        songsQueue.Dequeue();
                    }
                }
                else if (command.Contains("Add"))
                {
                    if (songsQueue.Contains(command = command.Replace("Add ", "")))
                    {
                        Console.WriteLine($"{command} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(command);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));

                }
                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}

