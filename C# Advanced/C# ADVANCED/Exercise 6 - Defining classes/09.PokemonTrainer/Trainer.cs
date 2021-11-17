using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int badges, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.NumberOfBadges = badges;
            this.Pokemons = pokemons;
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
