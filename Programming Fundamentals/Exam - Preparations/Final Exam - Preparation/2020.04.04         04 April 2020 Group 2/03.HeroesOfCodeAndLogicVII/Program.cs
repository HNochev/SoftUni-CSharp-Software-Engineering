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

                heroes.Add(hero[0], new List<int>());
                heroes[hero[0]].Add(int.Parse(hero[1]));
                heroes[hero[0]].Add(int.Parse(hero[2]));
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
                            if(heroes[heroName][1] >= int.Parse(command[2]))
                            {
                                heroes[heroName][1] -= int.Parse(command[2]);
                                Console.WriteLine($"{heroName} has successfully cast {command[3]} and now has {heroes[heroName][1]} MP!");
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} does not have enough MP to cast {command[3]}!");
                            }
                            break;
                        }
                    case "TakeDamage":
                        {
                            if(heroes[heroName][0] > int.Parse(command[2]))
                            {
                                heroes[heroName][0] -= int.Parse(command[2]);
                                Console.WriteLine($"{heroName} was hit for {int.Parse(command[2])} HP by {command[3]} and now has {heroes[heroName][0]} HP left!");
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} has been killed by {command[3]}!");
                                heroes.Remove(heroName);
                            }
                            break;
                        }
                    case "Recharge":
                        {
                            heroes[heroName][1] += int.Parse(command[2]);
                            int over200 = 0;

                            if (heroes[heroName][1] > 200)
                            {
                                over200 = heroes[heroName][1] - 200;
                                heroes[heroName][1] = 200;
                            }
                            Console.WriteLine($"{heroName} recharged for {int.Parse(command[2]) - over200} MP!");
                            break;
                        }
                    case "Heal":
                        {
                            heroes[heroName][0] += int.Parse(command[2]);
                            int over100 = 0;

                            if (heroes[heroName][0] > 100)
                            {
                                over100 = heroes[heroName][0] - 100;
                                heroes[heroName][0] = 100;
                            }
                            Console.WriteLine($"{heroName} healed for {int.Parse(command[2])- over100} HP!");
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var hero in heroes.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"    HP: {hero.Value[0]}");
                Console.WriteLine($"    MP: {hero.Value[1]}");
            }
        }
    }
}
