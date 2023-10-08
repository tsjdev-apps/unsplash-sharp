using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnsplashSharp.Models;

namespace UnsplashSharp
{
    public partial class UnsplashService : IUnsplashService
    {
        internal static readonly string BaseEndpoint = "https://api.unsplash.com/";

        internal const string PhotosEndpoint = "photos";
        internal const string PhotoEndpoint = "photos/{0}";
        internal const string RandomPhotosEndpoint = "photos/random";
        internal const string PhotoStatsEndpoint = "photos/{0}/statistics";
        internal const string PhotoDownloadEndpoint = "photos/{0}/download";
        internal const string TotalStatsEndpoint = "stats/total";
        internal const string MonthlyStatsEndpoint = "stats/month";
        internal const string UsersEndpoint = "users/{0}";
        internal const string UserPortfolioEndpoint = "users/{0}/portfolio";
        internal const string UserPhotosEndpoint = "users/{0}/photos";
        internal const string UserLikesEndpoint = "users/{0}/likes";
        internal const string UserCollectionsEndpoint = "users/{0}/collections";
        internal const string UserStatsEndpoint = "users/{0}/statistics";
        internal const string CollectionEndpoint = "collections/{0}";
        internal const string CollectionPhotosEndpoint = "collections/{0}/photos";
        internal const string CollectionsEndpoint = "collections";
        internal const string CollectionsRelatedEndpoint = "collections/{0}/related";
        internal const string SearchPhotosEndpoint = "search/photos";
        internal const string SearchCollectionsEndpoint = "search/collections";
        internal const string SearchUsersEndpoint = "search/users";
        internal const string TopicsEndpoint = "topics";
        internal const string TopicEndpoint = "topics/{0}";
        internal const string TopicPhotosEndpoint = "topics/{0}/photos";


        public string ApplicationId { get; internal set; }
        public int MaxRateLimit { get; internal set; }
        public int RateLimitRemaining { get; internal set; }


        public UnsplashService(string applicationId)
        {
            ApplicationId = applicationId;
        }

        internal string GetEndpointUrl(string type, string parameter = null)
        {
            switch (type)
            {
                case PhotosEndpoint:
                    return $"{BaseEndpoint}{PhotosEndpoint}";
                case PhotoEndpoint:
                    return BaseEndpoint + string.Format(PhotoEndpoint, parameter);
                case RandomPhotosEndpoint:
                    return $"{BaseEndpoint}{RandomPhotosEndpoint}";
                case PhotoStatsEndpoint:
                    return BaseEndpoint + string.Format(PhotoStatsEndpoint, parameter);
                case PhotoDownloadEndpoint:
                    return BaseEndpoint + string.Format(PhotoDownloadEndpoint, parameter);
                case TotalStatsEndpoint:
                    return $"{BaseEndpoint}{TotalStatsEndpoint}";
                case MonthlyStatsEndpoint:
                    return $"{BaseEndpoint}{MonthlyStatsEndpoint}";
                case UsersEndpoint:
                    return BaseEndpoint + string.Format(UsersEndpoint, parameter);
                case UserPortfolioEndpoint:
                    return BaseEndpoint + string.Format(UserPortfolioEndpoint, parameter);
                case UserPhotosEndpoint:
                    return BaseEndpoint + string.Format(UserPhotosEndpoint, parameter);
                case UserLikesEndpoint:
                    return BaseEndpoint + string.Format(UserLikesEndpoint, parameter);
                case UserCollectionsEndpoint:
                    return BaseEndpoint + string.Format(UserCollectionsEndpoint, parameter);
                case UserStatsEndpoint:
                    return BaseEndpoint + string.Format(UserStatsEndpoint, parameter);
                case CollectionsEndpoint:
                    return $"{BaseEndpoint}{CollectionsEndpoint}";
                case CollectionEndpoint:
                    return BaseEndpoint + string.Format(CollectionEndpoint, parameter);
                case CollectionPhotosEndpoint:
                    return BaseEndpoint + string.Format(CollectionPhotosEndpoint, parameter);
                case CollectionsRelatedEndpoint:
                    return BaseEndpoint + string.Format(CollectionsRelatedEndpoint, parameter);
                case SearchPhotosEndpoint:
                    return $"{BaseEndpoint}{SearchPhotosEndpoint}";
                case SearchCollectionsEndpoint:
                    return $"{BaseEndpoint}{SearchCollectionsEndpoint}";
                case SearchUsersEndpoint:
                    return $"{BaseEndpoint}{SearchUsersEndpoint}";
                case TopicsEndpoint:
                    return $"{BaseEndpoint}{TopicsEndpoint}";
                case TopicEndpoint:
                    return BaseEndpoint + string.Format(TopicEndpoint, parameter);
                case TopicPhotosEndpoint:
                    return BaseEndpoint + string.Format(TopicPhotosEndpoint, parameter);
                default:
                    return null;
            }
        }

        internal static void AddQueryString(ref string url, string queryName, object queryValue)
        {
            int indexQuestionMark = url.LastIndexOf("?");

            if (indexQuestionMark == -1)
            {
                url = string.Format("{0}?{1}={2}", url, queryName, queryValue.ToString().ToLower());
                return;
            }

            url = string.Format("{0}&{1}={2}", url, queryName, queryValue.ToString().ToLower());
        }

        internal async Task<T> GetAsync<T>(string url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", ApplicationId);
                httpClient.DefaultRequestHeaders.Add("Accept-Version", "v1");

                Debug.WriteLine($"URL: {url}");

                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBodyAsText = await response.Content.ReadAsStringAsync();

                T result = JsonConvert.DeserializeObject<T>(responseBodyAsText);

                UpdateRateLimit(response);

                return result;
            }
            catch
            {
                return default;
            }
        }

        internal void UpdateRateLimit(HttpResponseMessage response)
        {
            if (response.Headers.TryGetValues("X-Ratelimit-Limit", out IEnumerable<string> maxRateLimit))
            {
                MaxRateLimit = int.Parse(maxRateLimit.First());
            }

            if (response.Headers.TryGetValues("X-Ratelimit-Remaining", out IEnumerable<string> rateLimitRemaining))
            {
                RateLimitRemaining = int.Parse(rateLimitRemaining.First());
            }
        }

        internal string GetColorParamter(UnsplashColor unsplashColor)
        {
            if (unsplashColor == UnsplashColor.BlackAndWhite)
                return "black_and_white";

            return unsplashColor.ToString().ToLower();
        }

        internal int CheckPerPageValue(int perPage)
        {
            if (perPage < 0)
                return 1;

            if (perPage > 30)
                return 30;

            return perPage;
        }

        internal int CheckPageValue(int page)
        {
            if (page <= 0)
                return 1;

            return page;
        }

        internal int CheckQuantityValue(int quantity)
        {
            if (quantity <= 0)
                return 1;

            if (quantity > 30)
                return 30;

            return quantity;
        }
    }
}
