using PokeAPI.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.UI
{
    public class ProgramUI
    {
        private readonly PokemonService _pokemonService = new PokemonService();

        public async Task Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Please enter the name of a Pokemon");
                string input = Console.ReadLine();

                var pokemon = await _pokemonService.GetPokemonAsync(input.ToLower());
                if (pokemon == null)
                {
                    Console.WriteLine("Pokemon does not exist... Press any key to continue");
                    Console.ReadLine();
                    continue;
                }

                List<TypeDetail> typeDetails = new List<TypeDetail>();
                foreach (var type in pokemon.Types)
                {
                    var typeDetail = await _pokemonService.GetTypeDetailAsync(type.Type.Name);
                    if (typeDetail != null)
                    {
                        typeDetails.Add(typeDetail);
                    }
                }

                this.DisplayPokemon(pokemon);
                this.DisplayTypeDetails(typeDetails);

                Console.WriteLine("Do you want to search again? (y/n)");
                var response = Console.ReadLine().ToLower();

                if (response == "n")
                {
                    break;
                }
            }
        }

        private void DisplayPokemon(Pokemon pokemon)
        {
            Console.WriteLine($"Number: #{pokemon.Order}\n" +
                $"Name: {pokemon.Name.ToUpper()}\n" +
                $"Height: {pokemon.Height}\n" +
                $"Weight: {pokemon.Weight}\n");

            Console.WriteLine("Types:");
            foreach (var type in pokemon.Types)
            {
                Console.WriteLine($"{type.Type.Name.ToUpper()}");
            }
        }

        private void DisplayTypeDetails(List<TypeDetail> typeDetails)
        {
            foreach (var typeDetail in typeDetails)
            {
                Console.WriteLine($"\n{typeDetail.Name.ToUpper()} is super effective against:");
                foreach(var type in typeDetail.DamageRelations.DoubleDamageTo)
                {
                    Console.WriteLine(type.Name.ToUpper());
                }
            }
        }
    }
}
