using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item validItem;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            validItem = new Item("Valid", "Id");
        }

        [Test]
        public void AddItem_ThrowsException_WhenThisValutDoesntContainsKey()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("invalidCell", new Item("Owner", "Id")));
        }

        [Test]
        public void AddItem_ThrowsException_WhenTheCellIsAlreadyTaken()
        {
            bankVault.AddItem("A1", validItem);
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("A1", new Item("Owner", "Id")));
        }

        [Test]
        public void AddItem_ThrowsException_WhenWeUseItemWIthSameId()
        {
            bankVault.AddItem("A1", validItem);
            Assert.Throws<InvalidOperationException>(() => this.bankVault.AddItem("A2", new Item("Owner", validItem.ItemId)));
        }

        [Test]
        public void AddItem_ReturnCorrectValue_WhenWeAddNewItem()
        {
            string result = bankVault.AddItem("A1", validItem);
            Assert.That(result, Is.EqualTo($"Item:{validItem.ItemId} saved successfully!"));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("invalidCell", new Item("Owner", "Id")));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenItemInCellDoesntExistDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("A1", validItem));
        }

        [Test]
        public void RemoveItem_ReturnsCorrectValue_WhenUseCorrectItem()
        {
            bankVault.AddItem("A1", validItem);
            string result = bankVault.RemoveItem("A1", validItem);

            Assert.That(result, Is.EqualTo($"Remove item:{validItem.ItemId} successfully!"));
        }
    }
}