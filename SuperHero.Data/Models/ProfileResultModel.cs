using Newtonsoft.Json;

namespace SuperHero.Data.Models
{
    public class ProfileResultModel : ProfileModel
    {
        [JsonProperty("response")]
        public string Response { get; set; }
    }
}
