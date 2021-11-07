using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> filledBottles = new Stack<int>(bottles);
            Queue<int> cupsToFill = new Queue<int>(cupsCapacity);

            int wastedWater = 0;

            while (filledBottles.Any() && cupsToFill.Any())
            {
                int bottle = filledBottles.Pop();

                if (bottle < cupsToFill.Peek())
                {
                    int cup = cupsToFill.Dequeue();
                    cup = cup - bottle;
                    while (true)
                    {
                        int nowBottle = filledBottles.Pop();
                        if(nowBottle < cup)
                        {
                            cup = cup - nowBottle;
                        }
                        else
                        {
                            wastedWater += nowBottle - cup;
                            break;
                        }

                        if(filledBottles.Count == 0)
                        {
                            Console.WriteLine($"Cups: {string.Join(" ", cupsToFill)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");
                            return;
                        }
                    }
                }
                else if(bottle >= cupsToFill.Peek())
                {
                    wastedWater += bottle - cupsToFill.Peek();
                    cupsToFill.Dequeue();
                }
            }
            if (filledBottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", filledBottles)}");
            }
            else if (cupsToFill.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsToFill)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
