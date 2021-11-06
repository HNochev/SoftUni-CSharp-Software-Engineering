using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Paid" && customers.Count > 0)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, customers));
                    customers.Clear();
                    command = Console.ReadLine();
                    continue;
                }
                customers.Enqueue(command);

                command = Console.ReadLine();
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
