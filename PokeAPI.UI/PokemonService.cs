using PokeAPI.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.UI
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private const string baseUrl = "https://pokeapi.co/api/v2/";
        private const string pokemonRoute = "pokemon/";
        private const string typeRoute = "type/";

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}{pokemonRoute}{name}");

            return response.IsSuccessStatusCode 
                ? await response.Content.ReadAsAsync<Pokemon>() 
                : null;
        }

        public async Task<TypeDetail> GetTypeDetailAsync(string name)
        {
            var response = await _httpClient.GetAsync($"{baseUrl}{typeRoute}{name}");

            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<TypeDetail>()
                : null;
        }
    }
}
