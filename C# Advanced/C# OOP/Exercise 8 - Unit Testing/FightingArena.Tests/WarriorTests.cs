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
        [TestCase("", 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase(null, 50, 100)]
        [TestCase("WarriorName", 0, 100)]
        [TestCase("WarriorName", -50, 100)]
        [TestCase("WarriorName", 50, -10)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]
        public void Attack_ThrowsException_WhenHpIsLessThanMinimum(int attackerHp, int warriorHp)
        {
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior warrior = new Warrior("Warrior", 10, warriorHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenWarriorKillsTheAttacker()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", attacker.HP + 1, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_DecreaseAttackerHealthPoints()
        {
            int initialAttackerHP = 100;

            Warrior attacker = new Warrior("Attacker", 50, initialAttackerHP);
            Warrior warrior = new Warrior("Warrior", 30, 100);

            attacker.Attack(warrior);

            Assert.That(attacker.HP, Is.EqualTo(initialAttackerHP - warrior.Damage));
        }

        [Test]
        public void Attack_SetEnemyHealthPointsTOZero_WhenAttackerDamageIsGreaterThanEnemyHealth()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, 40);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_DecreaseEnemyHealthPointsByAttackerDamege()
        {
            int warriorInitialHP = 60;

            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrior", 30, warriorInitialHP);

            attacker.Attack(warrior);

            Assert.That(warrior.HP, Is.EqualTo(warriorInitialHP - attacker.Damage));
        }
    }
}