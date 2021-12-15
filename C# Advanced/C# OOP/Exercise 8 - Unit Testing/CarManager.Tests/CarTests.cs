using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Opel", "Astra", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -100)]
        public void Ctor_ThrowsExeption_WhenInvalidDataIsSent(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            string make = "Opel";
            string model = "Astra";
            double fuelConsumption = 5.5;
            double fuelCapacity = 55.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreaseFuelAmount_WhenFuelAmountISValid()
        {
            double refuelAmount = this.car.FuelCapacity / 2;

            this.car.Refuel(refuelAmount);

            Assert.That(this.car.FuelAmount, Is.EqualTo(refuelAmount));
        }

        [Test]
        public void Refuel_SetFuelAmountTOCapacity_WhenCapacityISExceeded()
        {
            this.car.Refuel(this.car.FuelCapacity * 1.2);

            Assert.That(this.car.FuelAmount, Is.EqualTo(this.car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowException_WHenFuelIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void Drive_DecreaseFuelAmount_WhenDistanceISValid()
        {
            double initialFuel = this.car.FuelCapacity;

            this.car.Refuel(initialFuel);

            this.car.Drive(100);

            Assert.That(this.car.FuelAmount, Is.EqualTo(initialFuel - this.car.FuelConsumption));
        }

        [Test]
        public void FuelAmount_ThrowsException_WhenNegativeValueISPassed()
        {
            this.car.Refuel(this.car.FuelCapacity);

            double beforeDrive = this.car.FuelAmount;

            this.car.Drive(100);

            double afterDrive = this.car.FuelAmount;

            Assert.That(afterDrive, Is.LessThan(beforeDrive));
        }
    }
}