using Newtonsoft.Json;
using System;

namespace UnsplashSharp.Models
{
    public class Collection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("last_collected_at")]
        public DateTime LastCollectedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("total_photos")]
        public int TotalPhotos { get; set; }

        [JsonProperty("_private")]
        public bool Private { get; set; }

        [JsonProperty("share_key")]
        public string ShareKey { get; set; }

        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }

        [JsonProperty("links")]
        public LinkInfo Links { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("cover_photo")]
        public Photo CoverPhoto { get; set; }

        [JsonProperty("preview_photos")]
        public PreviewPhotoLinks[] PreviewPhotos { get; set; }
    }
}
