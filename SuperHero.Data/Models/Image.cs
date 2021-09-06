using Newtonsoft.Json;
using System;

namespace SuperHero.Data.Models
{
    public partial class Image
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
