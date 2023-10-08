using Newtonsoft.Json;
using System;

namespace UnsplashSharp.Models
{
    public class PreviewPhotoLinks
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("blur_hash")]
        public string BlurHash { get; set; }

        [JsonProperty("urls")]
        public UrlLinks Urls { get; set; }
    }
}
