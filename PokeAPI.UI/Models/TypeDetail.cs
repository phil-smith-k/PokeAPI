using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.UI.Models
{
    public class TypeDetail
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("damage_relations")]
        public DamageRelationship DamageRelations { get; set; }
    }
}
