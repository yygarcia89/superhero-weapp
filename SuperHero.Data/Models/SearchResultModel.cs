﻿using Newtonsoft.Json;
using System;

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
        public Result[] Results { get; set; }
    }

    public partial class Result
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

    public partial class Appearance
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("height")]
        public string[] Height { get; set; }

        [JsonProperty("weight")]
        public string[] Weight { get; set; }

        [JsonProperty("eye-color")]
        public string EyeColor { get; set; }

        [JsonProperty("hair-color")]
        public string HairColor { get; set; }
    }

    public partial class Biography
    {
        [JsonProperty("full-name")]
        public string FullName { get; set; }

        [JsonProperty("alter-egos")]
        public string AlterEgos { get; set; }

        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }

        [JsonProperty("place-of-birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("first-appearance")]
        public string FirstAppearance { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }
    }

    public partial class Connections
    {
        [JsonProperty("group-affiliation")]
        public string GroupAffiliation { get; set; }

        [JsonProperty("relatives")]
        public string Relatives { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Powerstats
    {
        [JsonProperty("intelligence")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Intelligence { get; set; }

        [JsonProperty("strength")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Strength { get; set; }

        [JsonProperty("speed")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Speed { get; set; }

        [JsonProperty("durability")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Durability { get; set; }

        [JsonProperty("power")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Power { get; set; }

        [JsonProperty("combat")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Combat { get; set; }
    }

    public partial class Work
    {
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }
}
