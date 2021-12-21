namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("Test", 20);
            this.fish = new Fish("fishy");
        }

        [Test]
        [TestCase("", 30)]
        [TestCase(null, 30)]

        public void Ctor_ThrowsExeptionArgumentNull_WhenInvalidDataIsSent(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }
        [Test]
        [TestCase("Aqyarium", -1)]
        [TestCase("Aqyarium", -30)]
        public void Ctor_ThrowsExeptionArgument_WhenInvalidDataIsSent(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            string name = "asdf";
            int capacity = 50;

            Aquarium car = new Aquarium(name, capacity);

            Assert.That(car.Name, Is.EqualTo(name));
            Assert.That(car.Capacity, Is.EqualTo(capacity));
        }

        [Test]
        public void Count_IsNull_WhenAquariumEmpty()
        {
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_IsOne_WhenAquariumEmpty()
        {
            aquarium.Add(fish);

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenAquariumIsFull()
        {
            Aquarium aqua = new Aquarium("aaa", 1);
            aqua.Add(new Fish("sadfaasf"));

            Assert.Throws<InvalidOperationException>(() => aqua.Add(fish));
        }

        [Test]
        public void RemoveFish_ThrowsInvalidOperationException_WhenFishIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("qqq"));
        }
        [Test]
        public void Add_AddsFish_WhenEverythingIsFine()
        {
            Aquarium aqua = new Aquarium("aaa", 1);
            aqua.Add(new Fish("sadfaasf"));

            Assert.That(aqua.Count, Is.EqualTo(1));
        }
        [Test]
        public void RemoveFish_RemovesFish_WhenEverythingIsFine()
        {
            Aquarium aqua = new Aquarium("aaa", 1);
            aqua.Add(new Fish("sadfaasf"));
            aqua.RemoveFish("sadfaasf");

            Assert.That(aqua.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellFish_ThrowsInvalidOperationException_WhenFishIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("qqq"));
        }

        [Test]
        public void SellFish_ReturnsNeededFish_WhenFishIsCorrect()
        {
            aquarium.Add(fish);

            Fish result = aquarium.SellFish("fishy");


            Assert.That(result, Is.EqualTo(fish));
        }

        [Test]
        public void Report_ReturnsString_WhenEverythingIsCorrect()
        {
            aquarium.Add(fish);

            string result = aquarium.Report();


            Assert.That(result, Is.EqualTo($"Fish available at {aquarium.Name}: {fish.Name}"));
        }
    }
}
