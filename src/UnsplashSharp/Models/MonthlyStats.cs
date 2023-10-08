using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class MonthlyStats
    {
        [JsonProperty("downloads")]
        public int Downloads { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("new_photos")]
        public int NewPhotos { get; set; }

        [JsonProperty("new_photographers")]
        public int NewPhotographers { get; set; }

        [JsonProperty("new_pixels")]
        public long NewPixels { get; set; }

        [JsonProperty("new_developers")]
        public int NewDevelopers { get; set; }

        [JsonProperty("new_applications")]
        public int NewApplications { get; set; }

        [JsonProperty("new_requests")]
        public int NewRequests { get; set; }
    }
}
