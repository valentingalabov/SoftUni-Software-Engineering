using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> pokemonTrainers = new List<Trainer>();
            string inputLine = Console.ReadLine();
            while (inputLine != "Tournament")
            {
                string[] tokens = inputLine
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonType = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonType, pokemonHealth);
                currentTrainer.Pokemons.Add(currentPokemon);
                bool wasAdded = false;
                foreach (var trainer in pokemonTrainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        trainer.Pokemons.Add(currentPokemon);
                        wasAdded = true;
                        break;
                    }
                }
                if (!wasAdded)
                    pokemonTrainers.Add(currentTrainer);
                inputLine = Console.ReadLine();
            }
            inputLine = Console.ReadLine();
            while (inputLine != "End")
            {
                string type = inputLine;
                for (int i = 0; i < pokemonTrainers.Count; i++)
                {
                    Trainer currentTrainer = pokemonTrainers[i];
                    if (currentTrainer.ContainsType(type))
                        currentTrainer.NumberOfBadges++;
                    else
                    {
                        currentTrainer.DecreaseHealth();
                        currentTrainer.RemoveDeadPokemons();
                    }
                }
                inputLine = Console.ReadLine();
            }
            pokemonTrainers = pokemonTrainers.OrderByDescending(trainer => trainer.NumberOfBadges).ToList();
            foreach (var trainer in pokemonTrainers)
            {
                trainer.PrintTrainerInfo();
            }
        }
    }
}
