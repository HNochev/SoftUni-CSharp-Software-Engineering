using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionModifier = 1.4;
        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, BusAirConditionModifier)
        {
        }

        public void DriveEmpty(double distance)
        {
            double neededFuel = this.FuelConsumptionPerKM * distance;

            if (neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity = this.FuelQuantity - neededFuel;
        }
    }
}
