using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private Product product;
        private StoreManager storeManager;

        [SetUp]
        public void Setup()
        {
            this.product = new Product("Test", 10, 10.00m);
            this.storeManager = new StoreManager();
            this.storeManager.AddProduct(product);
        }

        [Test]
        [Category("ProductConstructor")]
        public void ProductShouldInitializeDataCorrectly()
        {
            this.product = new Product("a", 1, 1);
            Assert.IsNotNull(product);
            Assert.AreEqual("a", this.product.Name);
            Assert.AreEqual(1, this.product.Quantity);
            Assert.AreEqual(1, this.product.Price);
        }

        [Test]
        [Category("StoreManagerConstructor")]
        public void ConstructorShouldInitializeDataCorrectly()
        {
            this.storeManager = new StoreManager();

            Assert.IsNotNull(this.storeManager);
            Assert.IsNotNull(this.storeManager.Products);
            Assert.AreEqual(0, this.storeManager.Count);
        }

        [Test]
        [Category("CountProperty")]
        public void CountProductsShouldWorkCorrectly()
        {
            Assert.AreEqual(1, this.storeManager.Count);
        }


        [Test]
        [Category("AddMethod")]
        public void AddMethodShouldWorkCorrectly()
        {
            Assert.AreEqual(1, this.storeManager.Count);

            var secondProduct = new Product("A", 1, 10);
            this.storeManager.AddProduct(secondProduct);

            Assert.AreEqual(2, this.storeManager.Count);
        }

        [Test]
        [Category("AddMethod")]
        public void PassNullProductToAddMethodShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => this.storeManager.AddProduct(null));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        [Category("AddMethod")]
        public void ZeroOrNegativeProductQuantityShouldThrowException(int quantity)
        {
            Assert.Throws<ArgumentException>(() => this.storeManager.AddProduct(new Product("X", quantity, 10.00m)));
        }

        [Test]
        [Category("BuyMethod")]
        public void BuyProductMethodShouldWorkCorrectly()
        {
            this.storeManager.BuyProduct("Test", 5);
            Assert.AreEqual(5, this.product.Quantity);
        }

        [Test]
        [Category("BuyMethod")]
        public void BuyProductWhichIsNotInTheCollectionShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => this.storeManager.BuyProduct("Invalid", 2));
        }

        [Test]
        [Category("BuyMethod")]
        public void BuyProductWhichDoesNotHaveEnaughQuantityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.storeManager.BuyProduct("Test", 15));
        }

        [Test]
        [Category("GetMostExpensiveProduct")]
        public void GetMostExpensiveProductShouldWorkCorrectly()
        {
            var product1 = new Product("A", 5, 5);
            var product2 = new Product("B", 15, 15);
            var product3 = new Product("C", 1, 1);
            var product4 = new Product("D", 4, 4);

            this.storeManager.AddProduct(product1);
            this.storeManager.AddProduct(product2);
            this.storeManager.AddProduct(product3);
            this.storeManager.AddProduct(product4);

            Product mostExpensiveProduct = this.storeManager.GetTheMostExpensiveProduct();
            Assert.AreEqual(product2, mostExpensiveProduct);
        }


    }
}