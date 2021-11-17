using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] inputElements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputElements[0];
                string pokemonName = inputElements[1];
                string element = inputElements[2];
                int health = int.Parse(inputElements[3]);

                Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>());
                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                if (trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Where(x => x.Name == trainerName).FirstOrDefault().Pokemons.Add(pokemon);
                }
                else
                {
                    trainers.Add(trainer);
                    trainer.Pokemons.Add(pokemon);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == input))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
