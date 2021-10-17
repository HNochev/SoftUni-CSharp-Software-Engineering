using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = cmdArg[0].ToLower();
                string model = cmdArg[1];
                string color = cmdArg[2].ToLower();
                int hp = int.Parse(cmdArg[3]);

                Vehicle currentVehicle = new Vehicle(type, model, color, hp);

                catalogue.Add(currentVehicle);

                command = Console.ReadLine();
            }

            string secondCommand = Console.ReadLine();
            while (secondCommand != "Close the Catalogue")
            {
                string modelType = secondCommand;
                Vehicle printCar = catalogue.First(x => x.Model == modelType);

                Console.WriteLine(printCar);

                secondCommand = Console.ReadLine();
            }

            List<Vehicle> onlyCars = catalogue
                .Where(x => x.Type == "car")
                .ToList();
            List<Vehicle> onlyTrucks = catalogue
                .Where(x => x.Type == "truck")
                .ToList();

            double totalCarsHp = onlyCars
                .Sum(x => x.HorsePower);
            double totalTrucksHp = onlyTrucks
                .Sum(x => x.HorsePower);

            double averageCarHp = 0.00;
            double averageTruckHp = 0.00;

            if(onlyCars.Count > 0)
            {
                averageCarHp = totalCarsHp / onlyCars.Count;
            }
            if(onlyTrucks.Count > 0)
            {
                averageTruckHp = totalTrucksHp / onlyTrucks.Count;
            }
            Console.WriteLine($"Cars have average horsepower of: {averageCarHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHp:f2}.");

        }
    }
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string color, int hp)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = hp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }
    }
}
