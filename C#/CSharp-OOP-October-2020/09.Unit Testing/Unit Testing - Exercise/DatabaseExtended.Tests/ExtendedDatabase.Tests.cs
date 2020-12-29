using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase edb;
        private Person[] people;
        [SetUp]
        public void Setup()
        {
            this.people = new Person[] { new Person(1, "1"), new Person(2, "2") };
            this.edb = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void ConstructorShouldInitializeDatabaseCorrectly()
        {
            Assert.AreEqual(edb.Count, people.Length);
        }

        [Test]
        public void InitializeDatabaseWithMoreThanAllowedPeopleShouldThrowException()
        {
            this.people = new Person[]
            {
                new Person(1,"A"),
                new Person(2,"B"),
                new Person(3,"C"),
                new Person(4,"D"),
                new Person(5,"F"),
                new Person(6,"G"),
                new Person(7,"H"),
                new Person(8,"I"),
                new Person(9,"J"),
                new Person(10,"K"),
                new Person(11,"L"),
                new Person(12,"M"),
                new Person(13,"N"),
                new Person(14,"O"),
                new Person(15,"P"),
                new Person(16,"Q"),
                new Person(17,"R"),
            };
            Assert.Throws<ArgumentException>(() => edb = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void AddPersonWithSameUsernameShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => edb.Add(new Person(100, "1")));
            Assert.AreEqual(people.Length, edb.Count);
        }

        [Test]
        public void AddPersonWithSameIdShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => edb.Add(new Person(1, "A")));
        }

        [Test]
        public void AddMorePeopleThanAllowedShouldThrowException()
        {
            this.people = new Person[]
            {
                new Person(1,"A"),
                new Person(2,"B"),
                new Person(3,"C"),
                new Person(4,"D"),
                new Person(5,"F"),
                new Person(6,"G"),
                new Person(7,"H"),
                new Person(8,"I"),
                new Person(9,"J"),
                new Person(10,"K"),
                new Person(11,"L"),
                new Person(12,"M"),
                new Person(13,"N"),
                new Person(14,"O"),
                new Person(15,"P"),
                new Person(16,"Q"),
            };

            this.edb = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => edb.Add(new Person(17, "R")));
        }

        [Test]
        public void AddPersonShouldWorkCorrectly()
        {
            edb.Add(new Person(3, "3"));
            Assert.AreEqual(people.Length + 1, edb.Count);
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            edb.Remove();
            Assert.AreEqual(people.Length - 1, edb.Count);
        }

        [Test]
        public void RemovePersonFromEmptyDatabaseShouldThrowException()
        {
            edb.Remove();
            edb.Remove();
            Assert.Throws<InvalidOperationException>(() => edb.Remove());
        }

        [Test]
        public void FindByUsernameMethodShouldWorkCorrectly()
        {
            var person = people[0];
            var searchedPerson = edb.FindByUsername("1");
            Assert.AreEqual(person, searchedPerson);
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfNoSuchUserExistInArray()
        {
            Assert.Throws<InvalidOperationException>(() => edb.FindByUsername("DoesntExist"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameMethodShouldThrowExceptionIfNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => edb.FindByUsername(username));
        }

        [Test]
        public void FindByIdMethodShouldWorkCorrectly()
        {
            var person = people[0];
            var searchedPerson = edb.FindById(1);
            Assert.AreEqual(person, searchedPerson);
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfNoUserExistWithSuchIdNumber()
        {
            Assert.Throws<InvalidOperationException>(() => edb.FindById(155));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdNumberIsLessThan0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => edb.FindById(-1));
        }

    }
}