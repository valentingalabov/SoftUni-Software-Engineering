using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddRiderShouldWorkSuccessfuly()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider = new UnitRider("Ivan", motorcycle);

           string resultMessage = raceEntry.AddRider(rider);

            string expectedMessage = "Rider Ivan added in race.";

            Assert.AreEqual(expectedMessage,resultMessage);
            Assert.AreEqual(raceEntry.Counter, 1);
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionIfNull()
        {
            RaceEntry raceEntry = new RaceEntry();


            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null), "Rider cannot be null.");
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionIfRiderAlreadyExist()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider = new UnitRider("Ivan", motorcycle);

            string resultMessage = raceEntry.AddRider(rider);

            

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider), "Rider is already added.");
        }

       [Test]
        public void CalculateAverageHorsePowerShouldReturnAverageHorsePowerOfAllRiders()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle motorcycle1 = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider1 = new UnitRider("Ivan", motorcycle1);

            UnitMotorcycle motorcycle2 = new UnitMotorcycle("Honda", 24, 500);
            UnitRider rider2 = new UnitRider("Stoqn", motorcycle2);

            UnitMotorcycle motorcycle3 = new UnitMotorcycle("Yamaha", 78, 500);
            UnitRider rider3 = new UnitRider("Sam", motorcycle3);

            raceEntry.AddRider(rider1);
            raceEntry.AddRider(rider2);
            raceEntry.AddRider(rider3);

            var result = raceEntry.CalculateAverageHorsePower();
            var expectedResult = 54;

            Assert.AreEqual(expectedResult, result);
           
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnInvalidOperationExceptionWhenOnly2RidersAreAdded()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle motorcycle1 = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider1 = new UnitRider("Ivan", motorcycle1);

           
            raceEntry.AddRider(rider1);
           

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

    }
}