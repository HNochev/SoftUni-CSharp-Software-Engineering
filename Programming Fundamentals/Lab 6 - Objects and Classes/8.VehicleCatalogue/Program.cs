using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();


            while (input != "end")
            {
                string[] text = input
                    .Split('/', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string brand = text[1];
                string model = text[2];

                if (text[0] == "Truck")
                {
                    int weight = int.Parse(text[3]);
                    Truck truck = new Truck(brand, model, weight);
                    trucks.Add(truck);
                }
                else if (text[0] == "Car")
                {
                    int hp = int.Parse(text[3]);
                    Car car = new Car(brand, model, hp);
                    cars.Add(car);
                }
                input = Console.ReadLine();
            }
            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
            }
            Console.WriteLine(string.Join(Environment.NewLine, cars.OrderBy(x => x.Brand)));
            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }
            Console.WriteLine(string.Join(Environment.NewLine, trucks.OrderBy(x => x.Brand)));
        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }

        public override string ToString()
        {
            string write = ($"{Brand}: {Model} - {Weight}kg");

            return write;
        }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Hp { get; set; }
        public Car(string brand, string model, int hp)
        {
            this.Brand = brand;
            this.Model = model;
            this.Hp = hp;
        }

        public override string ToString()
        {
            string write = ($"{Brand}: {Model} - {Hp}hp");

            return write;
        }
    }
    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}
