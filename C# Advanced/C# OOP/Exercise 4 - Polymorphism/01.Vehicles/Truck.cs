using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionModifier = 1.6;

        public Truck(double fuel, double fuelConsumption) : base(fuel, fuelConsumption, TruckAirConditionModifier)
        {
        }

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity * 0.95);
        }
    }
}
