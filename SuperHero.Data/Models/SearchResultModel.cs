using Newtonsoft.Json;
using System.Collections.Generic;

namespace SuperHero.Data.Models
{
    public partial class SearchResultModel
    {
        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("results-for")]
        public string ResultsFor { get; set; }

        [JsonProperty("results")]
        public List<ProfileModel> Results { get; set; }        
    }
}
