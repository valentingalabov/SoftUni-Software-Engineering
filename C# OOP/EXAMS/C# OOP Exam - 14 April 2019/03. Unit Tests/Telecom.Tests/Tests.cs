namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void CreateNewPhone()
        {
            phone = new Phone("Nokia", "3310");

        }


        [Test]
        public void TestConstructorWorkCorrectly()
        {
            string expectedMake = "Nokia";
            string expectedModel = "3310";

            Assert.AreEqual(expectedMake, phone.Make);
            Assert.AreEqual(expectedModel, phone.Model);
        }

        [Test]
        public void TestIfMakeIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone testPhone = new Phone(null, "galaxy");
            });
        }

        [Test]
        public void TestIfMakeIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone testPhone = new Phone("", "galaxy");
            });
        }

        [Test]
        public void TestIFModelIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone testPhone = new Phone("Samsung", "");
            });
        }

        [Test]
        public void TestCountOfContactsWorkCorrectly()
        {
            phone.AddContact("Ivo","0894886632");
            phone.AddContact("Sasho","08948844632");

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestPhoneBookIfNameAlreadyExist()
        {
            phone.AddContact("Ivo", "0894886632");
            phone.AddContact("Sasho", "08948844632");

            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("Ivo", "204894541");
            });
        }

        [Test]
        public void TestCallWorkCorrectly()
        {
            phone.AddContact("Ivo", "0894886632");
            
            string expectedResult = $"Calling Ivo - 0894886632...";

            Assert.AreEqual(expectedResult, phone.Call("Ivo"));
        }

        [Test]
        public void TestCallingToPersonThatDontExist()
        {
            phone.AddContact("Ivo", "0894886632");
            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.Call("Sasho");
            });
        }
    }
}