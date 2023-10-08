using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class AncestryInfo
    {
        [JsonProperty("type")]
        public SlugInfo Type { get; set; }

        [JsonProperty("category")]
        public SlugInfo Category { get; set; }

        [JsonProperty("subcategory")]
        public SlugInfo Subcategory { get; set; }
    }
}
