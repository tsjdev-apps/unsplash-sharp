using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class Tag
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("source")]
        public SourceInfo Source { get; set; }
    }
}
