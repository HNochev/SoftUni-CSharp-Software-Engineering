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
            car.FuelQuantity = 55;
            car.FuelConsumption = 6.1;

            car.Drive(7);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
