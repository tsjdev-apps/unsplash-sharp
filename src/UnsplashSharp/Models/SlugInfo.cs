using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class SlugInfo
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }


        [JsonProperty("pretty_slug")]
        public string PrettySlug { get; set; }
    }
}
