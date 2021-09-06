using Newtonsoft.Json;

namespace SuperHero.Data.Models
{
    public partial class Work
    {
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }
}
