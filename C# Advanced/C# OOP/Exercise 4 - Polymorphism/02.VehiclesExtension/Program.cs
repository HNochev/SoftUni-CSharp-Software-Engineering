using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace _02.VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                string type = input[1];
                double parameter = double.Parse(input[2]);

                try
                {
                    if (type == nameof(Car))
                    {
                        ProcessCommand(car, command, parameter);
                    }
                    else if (type == nameof(Truck))
                    {
                        ProcessCommand(truck, command, parameter);
                    }
                    else if (type == nameof(Bus))
                    {
                        ProcessCommand(bus, command, parameter);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessCommand(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);

                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
            }
            else if (command == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(parameter);

                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(parameter);
            }
        }

        private static Vehicle CreateVehicle()
        {
            string[] vehicleInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleInput[0];
            double fuelQuantity = double.Parse(vehicleInput[1]);
            double consumption = double.Parse(vehicleInput[2]);
            double tankCapacity = double.Parse(vehicleInput[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, consumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, consumption, tankCapacity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, consumption, tankCapacity);
            }
            return vehicle;
        }
    }
}