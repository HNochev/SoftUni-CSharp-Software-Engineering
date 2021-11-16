using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire> tires = new List<Tire>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string[] tiresCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (tiresCommand[0] != "No")
            {
                int[] years = new int[4];
                double[] pressures = new double[4];

                int counterYear = 0;
                int counterPressure = 0;

                for (int i = 0; i < tiresCommand.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        years[counterYear] = int.Parse(tiresCommand[i]);
                        counterYear++;
                    }
                    else
                    {
                        pressures[counterPressure] = double.Parse(tiresCommand[i]);
                        counterPressure++;
                    }
                }

                tires.Add(new Tire(years, pressures));

                tiresCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] enginesCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (enginesCommand[0] != "Engines")
            {
                int horsePower = int.Parse(enginesCommand[0]);
                double cubicCapacity = double.Parse(enginesCommand[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));

                enginesCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (carInfo[0] != "Show")
            {
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = int.Parse(carInfo[3]);
                double fuelConsumption = int.Parse(carInfo[4]);

                int engineIndex = int.Parse(carInfo[5]);
                int tiresindex = int.Parse(carInfo[6]);

                double fuelAfter20Km = fuelQuantity - (fuelConsumption / 100 * 20);

                if (fuelAfter20Km >= 0 && year >= 2017 &&
                    engines[engineIndex].HorsePower > 330 &&
                    tires[tiresindex].Pressures.Sum() >= 9 &&
                    tires[tiresindex].Pressures.Sum() <= 10)
                {
                    cars.Add(new Car(make, model, year, engines[engineIndex], fuelAfter20Km));
                }

                carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
