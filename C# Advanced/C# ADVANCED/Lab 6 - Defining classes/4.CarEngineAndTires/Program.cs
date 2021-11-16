using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1,2.5),
                new Tire(1,2.4),
                new Tire(1,2.2),
                new Tire(1,2.3),
            };

            Engine engine = new Engine(600, 5.0);

            Car car = new Car("Opel", "Astra", 2005, 60, 4.1, engine, tires);

            Console.WriteLine($"{car.Make}");
            Console.WriteLine($"{car.Model}");
            Console.WriteLine($"{car.Year}");
            Console.WriteLine($"{car.FuelConsumption}");
            Console.WriteLine($"{car.FuelQuantity}");
            Console.WriteLine($"HP: {car.Engine.HorsePower}        -        Cubic Capacity: {car.Engine.CubicCapacity}");

            foreach (var tire in car.Tires)
            {
                Console.WriteLine($"Year: {tire.Year}   Pressure: {tire.Pressure}");
            }
        }
    }
}
