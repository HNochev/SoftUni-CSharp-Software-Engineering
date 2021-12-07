using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double CarAirConditionModifier = 0.9;

        public Car(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, CarAirConditionModifier)
        {
        }
    }
}
