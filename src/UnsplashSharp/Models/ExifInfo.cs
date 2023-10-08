using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class ExifInfo
    {
        [JsonProperty("make")]
        public string Brand { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("exposure_time")]
        public string ExposureTime { get; set; }

        [JsonProperty("apterture")]
        public string Aperture { get; set; }

        [JsonProperty("focal_length")]
        public string FocalLength { get; set; }

        [JsonProperty("iso")]
        public int? Iso { get; set; }
    }
}
