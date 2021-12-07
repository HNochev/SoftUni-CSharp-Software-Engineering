using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuel, double fuelConsumption, double airConditionModifier)
        {
            this.FuelQuantity = fuel;
            this.FuelConsumptionPerKM = fuelConsumption;
            this.AirConditionModifier = airConditionModifier;
        }

        private double AirConditionModifier { get; set; }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKM { get; private set; }

        public void Drive(double distance)
        {
            double neededFuel = (this.FuelConsumptionPerKM + this.AirConditionModifier) * distance;

            if (neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity = this.FuelQuantity - neededFuel;
        }

        public virtual void Refuel(double quantity)
        {
            this.FuelQuantity = this.FuelQuantity + quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
