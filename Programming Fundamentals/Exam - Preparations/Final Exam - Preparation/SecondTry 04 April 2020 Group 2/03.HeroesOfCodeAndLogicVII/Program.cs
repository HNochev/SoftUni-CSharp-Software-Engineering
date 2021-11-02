using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                string[] hero = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int HP = int.Parse(hero[1]);
                int MP = int.Parse(hero[2]);

                heroes.Add(hero[0], new List<int>());
                heroes[hero[0]].Add(HP);
                heroes[hero[0]].Add(MP);
            }

            string[] command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                string heroName = command[1];
                switch (command[0])
                {
                    case "CastSpell":
                        {
                            int manaNeeded = int.Parse(command[2]);
                            string spellName = command[3];

                            if(heroes[heroName][1] >= manaNeeded)
                            {
                                heroes[heroName][1] -= manaNeeded;
                                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                            }

                            break;
                        }
                    case "TakeDamage":
                        {
                            int damage = int.Parse(command[2]);
                            string attacker = command[3];

                            heroes[heroName][0] -= damage;
                            if(heroes[heroName][0] > 0)
                            {
                                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                                heroes.Remove(heroName);
                            }

                            break;
                        }
                    case "Recharge":
                        {
                            int mana = int.Parse(command[2]);
                            int overTheLimit = 0;

                            heroes[heroName][1] = heroes[heroName][1] + mana;

                            if(heroes[heroName][1] > 200)
                            {
                                overTheLimit = heroes[heroName][1] - 200;
                                heroes[heroName][1] = 200;
                            }
                            Console.WriteLine($"{heroName} recharged for {mana - overTheLimit} MP!");

                            break;
                        }
                    case "Heal":
                        {
                            int health = int.Parse(command[2]);
                            int overTheLimit = 0;

                            heroes[heroName][0] = heroes[heroName][0] + health;

                            if (heroes[heroName][0] > 100)
                            {
                                overTheLimit = heroes[heroName][0] - 100;
                                heroes[heroName][0] = 100;
                            }
                            Console.WriteLine($"{heroName} healed for {health - overTheLimit} HP!");
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var hero in heroes.OrderByDescending(x=>x.Value[0]).ThenBy(x=>x.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"    HP: {hero.Value[0]}");
                Console.WriteLine($"    MP: {hero.Value[1]}");
            }
        }
    }
}
