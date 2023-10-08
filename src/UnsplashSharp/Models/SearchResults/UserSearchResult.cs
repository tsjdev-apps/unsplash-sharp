using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnsplashSharp.Models.SearchResults
{
    internal class UserSearchResult
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("results")]
        public List<User> Users { get; set; }
    }
}
