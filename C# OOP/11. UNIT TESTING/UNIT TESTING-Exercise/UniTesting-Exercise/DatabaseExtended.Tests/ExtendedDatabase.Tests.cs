using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person person;

        [SetUp]
        public void Setup()
        {

            this.person = new Person(0, "Pesho");
            this.database = new ExtendedDatabase.ExtendedDatabase(person);
        }

        [Test]
        public void TestPersonConstructroWorkCorrectly()
        {
            string expectedPersonName = "Pesho";
            int expectedId = 0;



            Assert.AreEqual(expectedPersonName, person.UserName);
            Assert.AreEqual(expectedId, person.Id);

        }

        [Test]
        public void TestExtendedDatabaseConstructorWorkCorrectly()
        {
            int expectedCount = 1;


            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddRangeInConstructorWorkCorrectly()
        {

            Person[] people = new Person[18];
            for (int i = 1; i <= 16; i++)
            {
                string name = "ivo" + i.ToString();
                people[i] = new Person(i, "name");
            }

            Assert.Throws<ArgumentException>(() =>
            {
                ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(people);
            });
        }

        [Test]
        public void TestAddPeoppleWorkCorrectly()
        {
            int expectedCount = 2;

            var person = new Person(3, "Tisho");

            database.Add(person);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddWhenIsFull()
        {

            for (int i = 1; i < 16; i++)
            {
                string name = "pesho" + i.ToString();
                database.Add(new Person(i, name));
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "Acho"));
            });
        }

        [Test]
        public void TestIfThereIsUsertWithThatNameWhenAdd()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(5, "Pesho"));
            });
        }

        [Test]
        public void TestIfThereIsUserWIthSameIdWhenAdd()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(0, "Gencho"));
            });

        }

        [Test]
        public void TestRemoveWorkCorrectly()
        {
            int expectedCount = 0;
            database.Remove();
            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestRemoveWhenCountIsZero()
        {

            database.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void TestFindPersonByIdWorkCorrectly()
        {
            var findedPerson = database.FindById(0);

            Assert.AreEqual(person, database.FindById(0));
        }

        [Test]
        public void TestFindByIdWithNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-3);
            });
        }

        [Test]
        public void TestFindByIdWithWrongId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(2);
            });
        }

        [Test]
        public void TestFindingPersonByName()
        {
            Assert.AreEqual(person, database.FindByUsername("Pesho"));
        }

        [Test]
        public void TestFindingPersonByEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername("");
            });
        }

       
        [Test]
        public void TestFindingPersonByNameNotIncludetInDatabase()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Stoqn");
            });
        }
    }
}