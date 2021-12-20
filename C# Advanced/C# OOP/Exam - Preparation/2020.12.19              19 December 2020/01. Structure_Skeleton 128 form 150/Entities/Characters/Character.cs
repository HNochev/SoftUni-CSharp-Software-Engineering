using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; set; }

        public double Health { get; set; }

        public double BaseArmor { get; set; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (hitPoints - this.Armor > 0)
                {
                    hitPoints = hitPoints - this.Armor;
                    this.Armor = 0;
                    this.Health = this.Health - hitPoints;
                    if (this.Health < 0)
                    {
                        this.Health = 0;
                    }
                }
                else
                {
                    this.Armor = this.Armor - hitPoints;
                }

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}