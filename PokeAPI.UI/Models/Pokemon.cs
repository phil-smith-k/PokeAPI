using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.UI.Models
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("types")]
        public List<PokemonType> Types { get; set; }
    }
}
