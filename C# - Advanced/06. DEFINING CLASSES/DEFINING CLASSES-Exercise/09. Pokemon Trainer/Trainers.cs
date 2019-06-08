using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name;
        public int NumberOfBadges;
        public List<Pokemon> Pokemons;

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public bool ContainsType(string type)
        {
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Type == type)
                {
                    return true;
                }
            }
            return false;
        }

        public void DecreaseHealth()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].Health -= 10;
            }
        }

        public void RemoveDeadPokemons()
        {
            Pokemons = Pokemons.Where(pokemon => pokemon.Health > 0).ToList();
        }

        public void PrintTrainerInfo()
        {
            Console.WriteLine("{0} {1} {2}", Name, NumberOfBadges, Pokemons.Count);
        }

    }
}
