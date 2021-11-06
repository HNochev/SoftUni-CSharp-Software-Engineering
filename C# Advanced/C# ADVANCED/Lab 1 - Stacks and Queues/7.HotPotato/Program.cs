using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int counting = int.Parse(Console.ReadLine());
            int counter = 0;
            Queue<string> children = new Queue<string>(kids);

            while (children.Count != 1)
            {
                counter++;
                if(counter == counting)
                {
                    Console.WriteLine($"Removed {children.Dequeue()}");
                    counter = 0;
                }
                else
                {
                    children.Enqueue(children.Dequeue());
                }
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
