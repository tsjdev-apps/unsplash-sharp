using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class LocationInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("position")]
        public PositionInfo Position { get; set; }
    }
}
