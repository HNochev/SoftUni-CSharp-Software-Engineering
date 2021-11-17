using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => cars.Count();

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault();
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                cars = cars.Where(x => x.RegistrationNumber != number).ToList();
            }
        }
    }
}
