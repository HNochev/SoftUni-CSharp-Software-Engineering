using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuntity = double.Parse(Console.ReadLine());
            double fualConsumption = double.Parse(Console.ReadLine());

            Car car1 = new Car();
            Car car2 = new Car(make, model, year);
            Car car3 = new Car(make, model, year, fuelQuntity, fualConsumption);

            Console.WriteLine("-------------------1-----------------------");
            Console.WriteLine(car1.WhoAmI());
            Console.WriteLine("-------------------2-----------------------");
            Console.WriteLine(car2.WhoAmI());
            Console.WriteLine("-------------------3-----------------------");
            Console.WriteLine(car3.WhoAmI());
        }
    }
}
