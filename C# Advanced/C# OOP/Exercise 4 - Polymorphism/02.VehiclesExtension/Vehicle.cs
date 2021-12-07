using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuel;

        public Vehicle(double fuel, double fuelConsumption, double tankCapacity, double airConditionModifier)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuel;
            this.FuelConsumptionPerKM = fuelConsumption;
            this.AirConditionModifier = airConditionModifier;
        }

        protected double AirConditionModifier { get; set; }

        public double FuelQuantity
        {
            get => this.fuel;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuel = 0;
                }
                else
                {
                    this.fuel = value;
                }
            }
        }
        public double FuelConsumptionPerKM { get; private set; }

        public double TankCapacity { get; private set; }

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
            double neededCapacity = this.FuelQuantity + quantity;

            if (quantity <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }
            if (neededCapacity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {quantity} fuel in the tank");
            }

            this.FuelQuantity = this.FuelQuantity + quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
