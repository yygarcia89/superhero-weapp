using Newtonsoft.Json;

namespace SuperHero.Data.Models
{
    public partial class Connections
    {
        [JsonProperty("group-affiliation")]
        public string GroupAffiliation { get; set; }

        [JsonProperty("relatives")]
        public string Relatives { get; set; }
    }
}
