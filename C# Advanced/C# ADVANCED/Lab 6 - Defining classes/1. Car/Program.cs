using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Opel";
            car.Model = "Astra";
            car.Year = 1999;

            Console.WriteLine($"The car is: {car.Make} {car.Model} {car.Year}");
        }
    }
}
