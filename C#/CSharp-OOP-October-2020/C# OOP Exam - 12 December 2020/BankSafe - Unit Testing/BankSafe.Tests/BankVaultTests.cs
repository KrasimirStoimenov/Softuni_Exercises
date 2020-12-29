using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("Test", "Test1");
            this.bankVault = new BankVault();
        }

        [Test]
        [Category("Constructor")]
        public void ConstructorShouldInitializeDataCorrectly()
        {
            var bankVault = new BankVault();

            Assert.IsNotNull(bankVault);
        }

        [Test]
        [Category("AddItem")]
        public void AddItemMethodShouldWorkAsExpected()
        {
            var addedItem = this.bankVault.AddItem("A1", this.item);
            var expectedMessage = "Item:Test1 saved successfully!";

            Assert.AreEqual(expectedMessage, addedItem);
            Assert.AreEqual(this.item, this.bankVault.VaultCells["A1"]);
        }

        [Test]
        [Category("AddItem")]
        public void TryToAddItemToCellThatDoesntExistShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("Invalid", this.item));
        }

        [Test]
        [Category("AddItem")]
        public void TryToAddItemToCellThatAlreadyIsTakenShouldThrowException()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("A1", new Item("A", "A")));
        }

        [Test]
        [Category("AddItem")]
        public void TryToAddItemThatIsAlreadyInTheCellShouldThrowException()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<InvalidOperationException>(() => this.bankVault.AddItem("B1", this.item));
        }

        [Test]
        [Category("RemoveItem")]
        public void TryToRemoveItemFromCellThatDoesntExistShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("Invalid", this.item));
        }


        [Test]
        [Category("RemoveItem")]
        public void TryToRemoveItemThatDoesntExistFromCellShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("A2", this.item));
        }

        [Test]
        [Category("RemoveItem")]
        public void RemoveItemMethodShouldWorkAsExpected()
        {
            this.bankVault.AddItem("A1", this.item);

            var removedItem = this.bankVault.RemoveItem("A1", this.item);
            var expectedResult = "Remove item:Test1 successfully!";

            Assert.AreEqual(expectedResult, removedItem);
            Assert.AreEqual(null, this.bankVault.VaultCells["A1"]);
        }
    }
}