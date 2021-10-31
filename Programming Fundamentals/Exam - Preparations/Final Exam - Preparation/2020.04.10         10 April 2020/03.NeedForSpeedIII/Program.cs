using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Car
    {
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(string model, int mileage, int fuel)
        {
            this.Model = model;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public override string ToString()
        {
            return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int cars = int.Parse(Console.ReadLine());
            List<Car> automobiles = new List<Car>();

            for (int i = 0; i < cars; i++)
            {
                string[] car = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car c = new Car(car[0], int.Parse(car[1]), int.Parse(car[2]));
                automobiles.Add(c);
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] input = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (input[0])
                {
                    case "Drive":
                        {
                            string car = input[1];
                            int distance = int.Parse(input[2]);
                            int fuelNeeded = int.Parse(input[3]);

                            Car c = automobiles.Where(x => x.Model == car).FirstOrDefault();

                            if (c.Fuel < fuelNeeded)
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                            }
                            else
                            {
                                c.Fuel = c.Fuel - fuelNeeded;
                                c.Mileage = c.Mileage + distance;



                                Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                            }

                            if (c.Mileage >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {car}!");
                                automobiles.Remove(c);
                            }

                            break;
                        }
                    case "Refuel":
                        {
                            string car = input[1];
                            int fuel = int.Parse(input[2]);

                            Car c = automobiles.Where(x => x.Model == car).FirstOrDefault();

                            if (c.Fuel + fuel <= 75)
                            {
                                c.Fuel = c.Fuel + fuel;
                                Console.WriteLine($"{car} refueled with {fuel} liters");
                            }
                            else
                            {
                                int overFuel = (c.Fuel + fuel) - 75;
                                c.Fuel = 75;
                                Console.WriteLine($"{car} refueled with {fuel - overFuel} liters");
                            }
                            break;
                        }
                    case "Revert":
                        {
                            string car = input[1];
                            int kilometers = int.Parse(input[2]);

                            Car c = automobiles.Where(x => x.Model == car).FirstOrDefault();

                            c.Mileage = c.Mileage - kilometers;

                            if (c.Mileage >= 10000)
                            {
                                Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                            }
                            else
                            {
                                c.Mileage = 10000;
                            }
                            break;
                        }
                }
                command = Console.ReadLine();
            }
            foreach (var car in automobiles.OrderByDescending(x => x.Mileage).ThenBy(x => x.Model))
            {
                Console.WriteLine(car);
            }
        }
    }
}
