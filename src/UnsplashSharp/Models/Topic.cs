using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnsplashSharp.Models
{
    public class Topic
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("starts_at")]
        public DateTime StartsAt { get; set; }

        [JsonProperty("ends_at")]
        public DateTime? EndsAt { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("total_photos")]
        public int TotalPhotos { get; set; }

        [JsonProperty("links")]
        public LinkInfo Links { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("owners")]
        public List<User> Owners { get; set; }

        [JsonProperty("cover_photo")]
        public Photo CoverPhoto { get; set; }

        [JsonProperty("preview_photo")]
        public List<PreviewPhotoLinks> PreviewPhotos { get; set; }
    }
}
