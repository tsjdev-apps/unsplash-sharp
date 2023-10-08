using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class PhotoStats
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("downloads")]
        public StatInfo DownloadInfo { get; set; }

        [JsonProperty("views")]
        public StatInfo Views { get; set; }

        [JsonProperty("likes")]
        public StatInfo Likes { get; set; }
    }
}
