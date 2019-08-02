using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestConstructorWorkCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestIfEnrollWorksCorectly()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });

        }

        [Test]
        public void TestIfCountWorkCorrectly()
        {
            int expectedCount = 1;

            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, arena.Count);

        }

        [Test]
        public void TestIfFightsWorkCorrectly()
        {
            int expectedAttackerHp = 95;
            int expectedDeffenderHp = 40;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior deffender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);

            this.arena.Fight(attacker.Name, deffender.Name);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDeffenderHp, deffender.HP);

        }

        [Test]
        public void TestFightingMissingWarrior()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior deffender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, deffender.Name);
            });
        }

    }
}
