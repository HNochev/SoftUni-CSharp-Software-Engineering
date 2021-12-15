using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_IncreasesDatabaseCount_WhenAddIsValidOperation()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            Assert.That(this.database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_AddsElementToTheDatabase()
        {
            int element = 123;

            this.database.Add(element);

            int[] elements = this.database.Fetch();

            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Remove_DecreaseDatabaseCount()
        {
            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(3);

            this.database.Remove();

            int expectedCount = 2;

            Assert.That(this.database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_DecreaseElementFromDatabase()
        {
            int lastElement = 3;

            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(lastElement);

            this.database.Remove();

            int[] elements = this.database.Fetch();

            Assert.IsFalse(elements.Contains(lastElement));
        }

        [Test]
        public void Fetch_ReturnsDatabaseCopyInsteadOfReferance()
        {
            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(3);

            int[] elementsOne = this.database.Fetch();

            this.database.Remove();

            int[] elementsTwo = this.database.Fetch();

            CollectionAssert.AreNotEquivalent(elementsOne, elementsTwo);
        }

        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsEception_WhenDatabaseCapascityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Ctor_AddsElementsToDatabase()
        {
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            this.database = new Database.Database(array);

            Assert.That(this.database.Count, Is.EqualTo(array.Length));
            Assert.That(this.database.Fetch, Is.EquivalentTo(array));
        }
    }
}