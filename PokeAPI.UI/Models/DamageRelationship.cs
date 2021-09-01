using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.UI.Models
{
    public class DamageRelationship
    {
        [JsonProperty("double_damage_to")]
        public List<NamedAPIResource> DoubleDamageTo { get; set; }
    }
}
