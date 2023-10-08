using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class StatInfo
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("historical")]
        public HistoricalData HistoricalData { get; set; }
    }
}
