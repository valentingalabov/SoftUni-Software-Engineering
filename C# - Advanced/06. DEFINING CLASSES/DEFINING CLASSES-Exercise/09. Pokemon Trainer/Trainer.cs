using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private const int DefaultValueNumberOfBadges = 0;

        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = DefaultValueNumberOfBadges;
            this.Pokemons = new List<Pokemon>();
        }


        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
