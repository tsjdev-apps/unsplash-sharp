using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class PositionInfo
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
    }
}
