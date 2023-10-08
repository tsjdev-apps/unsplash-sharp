using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class UserStats
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("downloads")]
        public StatInfo DownloadInfo { get; set; }

        [JsonProperty("views")]
        public StatInfo Views { get; set; }
    }
}
