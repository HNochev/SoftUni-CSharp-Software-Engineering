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
        public void Ctor_InitializeWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowsException_WhenWarriorIsAlreadyExists()
        {
            string name = "Warrior";

            Warrior warrior = new Warrior(name, 50, 50);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior(name, 60, 60)));
        }

        [Test]
        public void Enroll_IncreaseArenaCount_WhenWarriorIsAdded()
        {
            int expextedCount = 4;

            this.arena.Enroll(new Warrior("1", 50, 50));
            this.arena.Enroll(new Warrior("2", 50, 50));
            this.arena.Enroll(new Warrior("3", 50, 50));
            this.arena.Enroll(new Warrior("4", 50, 50));

            Assert.That(this.arena.Count, Is.EqualTo(expextedCount));
        }

        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Warrior";

            this.arena.Enroll(new Warrior(name, 50, 50));

            Assert.That(this.arena.Warriors.Any(w => w.Name == name), Is.True);
        }


        [Test]
        public void Fight_ThrowsException_WhenDeffenderDoesNotExist()
        {
            string attacker = "Attacker";

            this.arena.Enroll(new Warrior(attacker, 50, 50));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker, "Deffender"));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerDoesNotExist()
        {
            string deffender = "Deffender";

            this.arena.Enroll(new Warrior(deffender, 50, 50));

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", deffender));
        }

        [Test]
        public void Fight_ThrowsException_WhenBothDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", "Deffender"));
        }

        [Test]
        public void Fight_BothWarriorsLoseHealthInFight()
        {
            int initialHP = 100;

            Warrior attacker = new Warrior("Attacker", 50, initialHP);
            Warrior deffender = new Warrior("Deffender", 60, initialHP);

            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);

            arena.Fight(attacker.Name, deffender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHP - deffender.Damage));
            Assert.That(deffender.HP, Is.EqualTo(initialHP - attacker.Damage));
        }
    }
}
