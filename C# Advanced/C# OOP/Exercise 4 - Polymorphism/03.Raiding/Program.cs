using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero baseHero = null;

                switch (type)
                {
                    case nameof(Druid):
                        {
                            heroes.Add(new Druid(name));
                            break;
                        }
                    case nameof(Paladin):
                        {
                            heroes.Add(new Paladin(name));
                            break;
                        }
                    case nameof(Rogue):
                        {
                            heroes.Add(new Rogue(name));
                            break;
                        }
                    case nameof(Warrior):
                        {
                            heroes.Add(new Warrior(name));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Invalid hero!");
                            continue;
                        }
                }

            }
            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int allHeroesPower = heroes.Sum(x => x.Power);

            if (allHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
