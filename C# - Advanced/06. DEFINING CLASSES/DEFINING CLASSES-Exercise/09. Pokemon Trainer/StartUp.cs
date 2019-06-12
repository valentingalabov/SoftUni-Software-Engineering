using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var trainers = new List<Trainer>();


            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                AddTrainerWithPokemon(trainers, tokens);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {

                CheckElement(input, trainers);



                input = Console.ReadLine();
            }

            Print(trainers);

        }

        private static void Print(List<Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(x=>x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        private static void CheckElement(string element, List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == element))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    foreach (var trainerPokemon in trainer.Pokemons)
                    {
                        trainerPokemon.Helth -= 10;
                    }
                }
            }

            foreach (var trainer in trainers)
            {
                trainer.Pokemons.RemoveAll(x => x.Helth <= 0);
            }
        }

        private static void AddTrainerWithPokemon(List<Trainer> trainers, string[] tokens)
        {
            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHelth = int.Parse(tokens[3]);

            Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);

            if (trainer == null)
            {
                trainer = new Trainer(trainerName);
                trainers.Add(trainer);
            }

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHelth);

            trainer.Pokemons.Add(pokemon);


        }
    }
}
