using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnsplashSharp.Models
{
    public class Photo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("promoted_at")]
        public DateTime? PromotedAt { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("blur_hash")]
        public string BlurHash { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("alt_description")]
        public string AltDescription { get; set; }

        [JsonProperty("urls")]
        public UrlLinks Urls { get; set; }

        [JsonProperty("links")]
        public PhotoLinks Links { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("liked_by_user")]
        public bool LikedByUser { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("exif")]
        public ExifInfo Exif { get; set; }

        [JsonProperty("location")]
        public LocationInfo Location { get; set; }

        [JsonProperty("public_domain")]
        public bool PublicDomain { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("downloads")]
        public int Downloads { get; set; }

        [JsonProperty("topics")]
        public List<Topic> Topics { get; set; }
    }
}
