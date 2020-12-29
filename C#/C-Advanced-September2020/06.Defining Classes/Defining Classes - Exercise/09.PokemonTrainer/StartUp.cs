using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            CatchingPokemnos(trainers);
            TakingBadges(trainers);
            PrintTrainers(trainers);
        }

        private static void PrintTrainers(List<Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine(trainer);
            }
        }

        private static void TakingBadges(List<Trainer> trainers)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "Fire":
                        CheckTrainersPokemons(trainers, "Fire");
                        break;
                    case "Water":
                        CheckTrainersPokemons(trainers, "Water");
                        break;
                    case "Electricity":
                        CheckTrainersPokemons(trainers, "Electricity");
                        break;
                }
            }
        }

        private static void CheckTrainersPokemons(List<Trainer> trainers, string type)
        {
            foreach (var trainer in trainers)
            {
                if (HaveValidPokemon(trainer.Pokemons, type))
                {
                    trainer.Badges++;
                }
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        Pokemon currentPokemon = trainer.Pokemons[i];
                        currentPokemon.Health -= 10;
                        if (currentPokemon.Health <= 0)
                        {
                            trainer.Pokemons.Remove(currentPokemon);
                        }
                    }
                }
            }
        }

        private static bool HaveValidPokemon(List<Pokemon> pokemons, string type)
        {
            Pokemon pokemon = pokemons.Find(x => x.Element == type);
            if (pokemon == null)
            {
                return false;
            }

            return true;
        }

        private static void CatchingPokemnos(List<Trainer> trainers)
        {
            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = trainers.Find(x => x.Name == trainerName);
                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }
                trainer.AddPokemon(pokemon);
            }
        }
    }
}
