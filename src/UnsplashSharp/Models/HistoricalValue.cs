using Newtonsoft.Json;
using System;

namespace UnsplashSharp.Models
{
    public class HistoricalValue
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
