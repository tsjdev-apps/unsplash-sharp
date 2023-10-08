using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class TotalStats
    {
        [JsonProperty("total_photos")]
        public long TotalPhotos { get; set; }

        [JsonProperty("photo_downloads")]
        public long PhotoDownloads { get; set; }

        [JsonProperty("photos")]
        public long Photos { get; set; }

        [JsonProperty("downloads")]
        public long Downloads { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("photographers")]
        public int Photographers { get; set; }

        [JsonProperty("pixels")]
        public long Pixels { get; set; }

        [JsonProperty("downloads_per_second")]
        public int DownloadsPerSecond { get; set; }

        [JsonProperty("views_per_second")]
        public int ViewsPerSecond { get; set; }
        
        [JsonProperty("developers")]
        public int Developers { get; set; }

        [JsonProperty("applications")]
        public int Applications { get; set; }

        [JsonProperty("requests")]
        public long Requests { get; set; }
    }
}
