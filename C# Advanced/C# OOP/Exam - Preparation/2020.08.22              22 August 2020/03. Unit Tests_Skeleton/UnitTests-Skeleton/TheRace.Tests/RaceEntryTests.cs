using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        RaceEntry raceEntry;
        UnitDriver driver;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            driver = new UnitDriver("Hris", new UnitCar("Opel", 82, 2.0));
        }

        [Test]
        public void Conter_IsNull_WhenEmpty()
        {
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }

        [Test]
        public void Conter_IsMoreThanNull_WhenHasResults()
        {
            raceEntry.AddDriver(driver);
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            driver = null;
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverExists()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(new UnitDriver("Hris", new UnitCar("aaa", 111, 111))));
        }

        [Test]
        public void AddDriver_ReturnsResult_WhenEverythingIsFine()
        {
            string result = raceEntry.AddDriver(driver);

            Assert.That(result, Is.EqualTo($"Driver {this.driver.Name} added in race."));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsException_WhenDriverCountIsLessThanMinimum()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
            this.raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsAverageHOrsePowers_WhenEverythingIsFine()
        {
            double averageTest = 0;
            for (int i = 0; i < 10; i++)
            {
                this.raceEntry.AddDriver(new UnitDriver(driver.Name + $"-{i}", new UnitCar("Opel", 100 + 3 * i, 2.0)));
                averageTest = averageTest + (100 + 3 * i);
            }
            averageTest = averageTest / 10;
            double average = raceEntry.CalculateAverageHorsePower();

            Assert.That(average, Is.EqualTo(averageTest));
        }
    }
}