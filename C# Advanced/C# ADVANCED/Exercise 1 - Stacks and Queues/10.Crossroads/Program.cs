using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();


            string carOrEnd = Console.ReadLine();
            int carsCount = 0;

            while (carOrEnd != "END")
            {
                int currGreen = greenLightDuration;
                int currFree = freeWindowDuration;

                if (carOrEnd == "green")
                {
                    while (currGreen > 0 && cars.Count != 0)
                    {
                        string firstInQueue = cars.Dequeue();
                        currGreen = currGreen - firstInQueue.Length;
                        if (currGreen >= 0)
                        {
                            carsCount++;
                        }
                        else
                        {
                            currFree = currFree + currGreen;
                            if (currFree < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstInQueue} was hit at {firstInQueue[firstInQueue.Length + currFree]}.");
                                return;
                            }
                            carsCount++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(carOrEnd);
                }
                carOrEnd = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsCount} total cars passed the crossroads.");
        }
    }
}
