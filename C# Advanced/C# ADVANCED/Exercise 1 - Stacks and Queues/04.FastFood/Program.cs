using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);
            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Any())
            {
                int order = ordersQueue.Peek();

                if (foodQuantity >= order)
                {
                    foodQuantity = foodQuantity - order;
                    ordersQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
