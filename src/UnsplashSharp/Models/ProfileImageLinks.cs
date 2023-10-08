using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class ProfileImageLinks
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }
}
