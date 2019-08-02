using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Vw", "Golf", 2, 10);
        }

        [Test]
        public void TestConstructorWorkCorrectly()
        {
            double expectedFuelAmout = 0;
            string expMake = "Vw";
            string expModel = "Golf";
            double expFuelConsumtion = 2;
            double expFuelCapacity = 10;

            Assert.AreEqual(expectedFuelAmout, car.FuelAmount);
            Assert.AreEqual(expMake, car.Make);
            Assert.AreEqual(expModel, car.Model);
            Assert.AreEqual(expFuelConsumtion, car.FuelConsumption);
            Assert.AreEqual(expFuelCapacity, car.FuelCapacity);
        }


        [Test]
        public void TestIfMakeIsNull()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car(null, "Ibiza", 2, 10);
            });

        }
        [Test]
        public void TestIfMakeIsEmpty()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("", "Ibiza", 2, 10);
            });

        }

        [Test]
        public void TestIfModeIslNull()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Seat", null, 2, 10);
            });

        }
        [Test]
        public void TestIfModeIsEmpty()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Seat", "", 2, 10);
            });

        }

        [Test]
        public void TestNegativeFuelConsumtion()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Seat", "Ibiza", -2, 10);
            });
        }

        [Test]
        public void TestNullFuelConsumtion()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Seat", "Ibiza", 0, 10);
            });
        }

        //[Test]
        //public void TestNegativeFuelAmount()
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {

        //    });
        //}

        [Test]
        public void TestNegativeFuelCapaccity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car newCar = new Car("Seat", "Ibiza", 2, -3);
            });
        }

        [Test]
        public void TestRefuelWorkCorrectly()
        {
            double expectedFuelAmount = 4; ;
            car.Refuel(4);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestRefuelIfFuelToRefuelIsMoreThanCapacity()
        {
            double expectedFuelAmount = 10;
            car.Refuel(200);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestRefuelIfFuelToRefuelIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-2);
            });
        }

        [Test]
        public void TestRefuelWithZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void TestDriveWorkCorrectly()
        {
            car.Refuel(10);
            car.Drive(100);
            double expectedFuelAmount = 8;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }

        [Test]
        public void TestDriveFuelNeededWorkCorrectly()
        {
            car.Refuel(10);
            car.Drive(100);
            double expectedFuelNeeded = 2;
            Assert.AreEqual(expectedFuelNeeded, car.FuelConsumption);
        }

        [Test]
        public void TestDriveDistanceIfExpectedFuelConsumptionIsNotEnought()
        {
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(200);
            });
        }

    }
}