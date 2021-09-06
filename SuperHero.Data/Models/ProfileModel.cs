﻿using Newtonsoft.Json;

namespace SuperHero.Data.Models
{
    public partial class ProfileModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("powerstats")]
        public Powerstats Powerstats { get; set; }

        [JsonProperty("biography")]
        public Biography Biography { get; set; }

        [JsonProperty("appearance")]
        public Appearance Appearance { get; set; }

        [JsonProperty("work")]
        public Work Work { get; set; }

        [JsonProperty("connections")]
        public Connections Connections { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }
    }
}
