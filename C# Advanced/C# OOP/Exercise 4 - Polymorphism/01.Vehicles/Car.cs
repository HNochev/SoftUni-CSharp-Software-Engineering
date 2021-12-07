using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditionModifier = 0.9;

        public Car(double fuel, double fuelConsumption) : base(fuel, fuelConsumption, CarAirConditionModifier)
        {
        }
    }
}
