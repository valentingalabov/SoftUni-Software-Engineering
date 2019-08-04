namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark park;
        

        [SetUp]
        public void Setup()
        {
            car = new Car("VW", "CT5555KK");

            park = new SoftPark();
           
        }

        [Test]
        public void TestCarConstructorWorkCorrectly()
        {
            string expectedModel = "VW";
            string expectedRegistrationNumber = "CT5555KK";

            Assert.AreEqual(expectedModel, car.Make);
            Assert.AreEqual(expectedRegistrationNumber, car.RegistrationNumber);

        }

        [Test]
        public void TestParkingCarWorkCorrectly()
        {
            string ecpectedResult = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(ecpectedResult, park.ParkCar("A1", car));
        }

        [Test]
        public void TestParkCarIfParkingSlotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                park.ParkCar("AAA", car);
            });
        }

        [Test]
        public void TestParkCarIfSpotIsAlreadyTaken()
        {
            Car newCar = new Car("BMW", "CB7040AP");

            park.ParkCar("A1", car);


            Assert.Throws<ArgumentException>(() =>
            {
                park.ParkCar("A1", newCar);
            });
        }

        [Test]
        public void TestParkCarIfRegistrationNumberAlreadyExist()
        {
            Car newCar = new Car("BMW", "CT5555KK");

            park.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                park.ParkCar("A2", newCar);
            });
        }

        [Test]
        public void TestRemoveCarWorkCorrectly()
        {
            Car newCar = new Car("BMW", "CT9999KK");
            park.ParkCar("A1", car);
            park.ParkCar("A2", newCar);

            string expectedResult = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(expectedResult, park.RemoveCar("A1", car));
        }

        [Test]
        public void TestRemoveCarIfParkSpotDoestnExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                park.RemoveCar("AaaA", car);
            });
        }

        [Test]
        public void TestRemoveCarFromSpotWithAnotherCar()
        {
            Car newCar = new Car("BMW", "CT9999KK");
            park.ParkCar("A1", car);
            park.ParkCar("A2", newCar);

            Assert.Throws<ArgumentException>(() =>
            {
                park.RemoveCar("A1", newCar);
            });
        }

        [Test]
        public void TestCountOfParkingSpots()
        {
            int expectedCount = 12;
            Assert.AreEqual(expectedCount, park.Parking.Count);
        }
    }
}