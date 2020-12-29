using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private int[] array;

        [SetUp]
        public void Setup()
        {
            this.array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            this.database = new Database.Database(array);
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void ConstructorShouldInitializeCorrectly(int[] arr)
        {
            this.database = new Database.Database(arr);
            CollectionAssert.AreEqual(arr, database.Fetch());
            Assert.AreEqual(arr.Length, database.Fetch().Length);
        }

        [Test]
        public void SizeOfTheArrayShouldNotExceed16ElementsAndShouldThrowException()
        {
            database.Add(16);
            Assert.Throws<InvalidOperationException>(() => database.Add(17), "Array's capacity must be exactly 16 integers!");
            Assert.AreEqual(16, database.Count);
        }

        [Test]
        public void AddMethodShouldAddElementAtNextFreeCell()
        {
            this.database.Add(16);

            var expectedResult = 16;
            var actualResult = this.database.Fetch()[15];
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [Test]
        public void RemoveMethodShouldRemoveElementAtLastFilledIndex()
        {
            this.database.Remove();
            Assert.AreEqual(this.array.Length - 1, this.database.Count);
            this.database.Remove();
            Assert.AreEqual(this.array.Length - 2, this.database.Count);

        }

        [Test]
        public void RemoveElementFromEmptyDatabaseShouldThrowException()
        {
            this.array = new int[] { };
            this.database = new Database.Database(array);

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnCopyOfTheArray()
        {
            CollectionAssert.AreEqual(this.array, this.database.Fetch());
        }
    }
}