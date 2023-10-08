using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class HistoricalData
    {
        [JsonProperty("change")]
        public int Change { get; set; }

        [JsonProperty("average")]
        public int Average { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("values")]
        public HistoricalValue[] Values { get; set; }
    }
}
