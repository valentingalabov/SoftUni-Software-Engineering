using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructirWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDmg = 15;
            int expectedHp = 100;

            Warrior warrior = new Warrior("Pesho", 15, 100);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("", 25, 100);
            });
        }

        [Test]
        public void TesTWithLikeSpaceName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("   ", 25, 100);
            });
        }

        [Test]
        public void TestWithLikeZeroDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 0, 10);
            });
        }

        [Test]
        public void TestWithLikeNegativeDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", -10, 10);
            });
        }

        [Test]
        public void TestWithLikeNegativeHp()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 20, -10);
            });
        }

        [Test]
        public void TestIfAttackWorksCorrectly()
        {
            int expectedAttackerHp = 95;
            int expectedDeffenderHp = 80;


            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior deffender = new Warrior("Sasho", 5, 90);

            attacker.Attack(deffender);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDeffenderHp, deffender.HP);
        }

        [Test]
        public void TestAttackingWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior deffender = new Warrior("Gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });

        }

        [Test]
        public void TestAttackingEnemyWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior deffender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void TestAttackingStrongerEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 10, 35);
            Warrior deffender = new Warrior("Gosho", 40, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void TestKillingEnemy()
        {
            int expectedAttHp = 55;
            int expectedDeffHp = 0;

            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior deffender = new Warrior("Gosho", 45, 40);

            attacker.Attack(deffender);

            Assert.AreEqual(expectedAttHp, attacker.HP);
            Assert.AreEqual(expectedDeffHp, deffender.HP);

        }
    }
}