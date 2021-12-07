using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionModifier = 1.6;

        public Truck(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, TruckAirConditionModifier)
        {
        }

        public override void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }
            if (this.FuelQuantity + quantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {quantity} fuel in the tank");
            }

            this.FuelQuantity = this.FuelQuantity + quantity * 0.95;
        }
    }
}
