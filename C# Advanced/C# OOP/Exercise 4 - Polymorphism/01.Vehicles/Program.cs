using System;
using System.Security.Cryptography;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string type = input[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(input[2]);

                    try
                    {
                        if (type == nameof(Car))
                        {
                            car.Drive(distance);
                        }
                        else if (type == nameof(Truck))
                        {
                            truck.Drive(distance);
                        }

                        Console.WriteLine($"{type} travelled {distance} km");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    double liters = double.Parse(input[2]);

                    if (type == nameof(Car))
                    {
                        car.Refuel(liters);
                    }
                    else if (type == nameof(Truck))
                    {
                        truck.Refuel(liters);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Vehicle CreateVehicle()
        {
            string[] vehicleInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleInput[0];
            double fuelQuantity = double.Parse(vehicleInput[1]);
            double consumption = double.Parse(vehicleInput[2]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, consumption);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, consumption);
            }

            return vehicle;
        }
    }
}
