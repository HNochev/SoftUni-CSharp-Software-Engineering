using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                cars.Add(car[0], new List<int>());
                cars[car[0]].Add(int.Parse(car[1]));
                cars[car[0]].Add(int.Parse(car[2]));
            }

            string[] command = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Stop")
            {
                string carName = command[1];
                switch (command[0])
                {
                    case "Drive":
                        {
                            int distance = int.Parse(command[2]);
                            int fuel = int.Parse(command[3]);

                            if (cars[carName][1] >= fuel)
                            {
                                cars[carName][1] -= fuel;
                                cars[carName][0] += distance;
                                Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                                if (cars[carName][0] >= 100000)
                                {
                                    cars.Remove(carName);
                                    Console.WriteLine($"Time to sell the {carName}!");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                            }
                            break;
                        }
                    case "Refuel":
                        {
                            int fuel = int.Parse(command[2]);
                            int moreFuel = 0;

                            cars[carName][1] += fuel;

                            if (cars[carName][1] > 75)
                            {
                                moreFuel = cars[carName][1] - 75;
                                cars[carName][1] = 75;
                            }

                            Console.WriteLine($"{carName} refueled with {fuel - moreFuel} liters");

                            break;
                        }
                    case "Revert":
                        {
                            int kilometers = int.Parse(command[2]);

                            cars[carName][0] -= kilometers;

                            if(cars[carName][0] < 10000)
                            {
                                cars[carName][0] = 10000;
                            }
                            else
                            {
                                Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                            }
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in cars.OrderByDescending(x=>x.Value[0]).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}
