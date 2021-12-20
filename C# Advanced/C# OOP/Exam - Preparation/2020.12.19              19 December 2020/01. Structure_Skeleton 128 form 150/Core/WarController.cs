using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> party;
        private List<Item> itemPool;

        public WarController()
        {
            this.party = new List<Character>();
            this.itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            if (characterType == "Warrior")
            {
                party.Add(new Warrior(name));
                return $"{name} joined the party!";
            }
            else if (characterType == "Priest")
            {
                party.Add(new Priest(name));
                return $"{name} joined the party!";
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{ characterType }\"!");

            }
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            if (itemName == "FirePotion")
            {
                itemPool.Add(new FirePotion());
                return $"{itemName} added to pool.";
            }
            else if (itemName == "HealthPotion")
            {
                itemPool.Add(new HealthPotion());
                return $"{itemName} added to pool.";
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{ itemName }\"!");
            }
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (party.Any(c => c.Name == characterName))
            {
                if (itemPool.Count <= 0)
                {
                    throw new InvalidOperationException("No items left in pool!");
                }

                Item itemToTake = itemPool[itemPool.Count - 1];

                party.First(c => c.Name == characterName).Bag.AddItem(itemToTake);

                itemPool.RemoveAt(itemPool.Count - 1);

                return $"{characterName} picked up {itemToTake.GetType().Name}!";
            }
            else
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (party.Any(c => c.Name == characterName))
            {
                Character character = party.First(c => c.Name == characterName);
                Item item = character.Bag.GetItem(itemName);

                character.UseItem(item);
                return $"{character.Name} used {itemName}.";
            }
            else
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                if (character.IsAlive)
                {
                    sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Alive");
                }
                else
                {

                    sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Dead");

                }
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string recieverName = args[1];

            if (!party.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (!party.Any(x => x.Name == recieverName))
            {
                throw new ArgumentException($"Character {recieverName} not found!");
            }

            Character reciever = party.First(x => x.Name == recieverName);

            if (party.First(x => x.Name == attackerName).GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Warrior attacker = (Warrior)party.First(x => x.Name == attackerName);

            StringBuilder sb = new StringBuilder();

            attacker.Attack(reciever);

            sb.AppendLine($"{attackerName} attacks {recieverName} for {attacker.AbilityPoints} hit points! {recieverName} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!");

            if (!reciever.IsAlive)
            {
                sb.AppendLine($"{reciever.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReciverName = args[1];

            if (!party.Any(x => x.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (!party.Any(x => x.Name == healingReciverName))
            {
                throw new ArgumentException($"Character {healingReciverName} not found!");
            }

            Character healingReciever = party.First(x => x.Name == healingReciverName);

            if (party.First(x => x.Name == healerName).GetType().Name != "Priest")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Priest healer = (Priest)party.First(x => x.Name == healerName);

            healer.Heal(healingReciever);

            return $"{healer.Name} heals {healingReciever.Name} for {healer.AbilityPoints}! {healingReciever.Name} has {healingReciever.Health} health now!";
        }
    }
}
