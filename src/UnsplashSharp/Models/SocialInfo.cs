using Newtonsoft.Json;

namespace UnsplashSharp.Models
{
    public class SocialInfo
    {
        [JsonProperty("instagram_username")]
        public string InstagramUsername { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("twitterUsername")]
        public string TwitterUsername { get; set; }

        [JsonProperty("paypal_email")]
        public string PayPalEmail { get; set; }
    }
}
