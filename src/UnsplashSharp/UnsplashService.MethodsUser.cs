using System.Collections.Generic;
using System.Threading.Tasks;
using UnsplashSharp.Models;
using UnsplashSharp.Models.Enums;
using UnsplashSharp.Models.Helpers;

namespace UnsplashSharp
{
    public partial class UnsplashService
    {
        /// <inheritdoc/>
        public async Task<User> GetUserAsync(
            string username)
        {
            string url = GetEndpointUrl(UsersEndpoint, username);

            User user = await GetAsync<User>(url);
            return user;
        }

        /// <inheritdoc/>
        public async Task<string> GetUserPorfolioLinkAsync(
            string username)
        {
            string url = GetEndpointUrl(UserPortfolioEndpoint, username);

            UrlInfo urlInfo = await GetAsync<UrlInfo>(url);
            return urlInfo.Url;
        }

        /// <inheritdoc/>
        public async Task<List<Photo>> GetUserPhotosAsync(
            string username, 
            int page = 1, 
            int perPage = 10,
            PhotoOrderBy orderBy = PhotoOrderBy.Latest, 
            bool stats = false, 
            int quantity = 30,
            Orientation orientation = Orientation.All)
        {

            string url = GetEndpointUrl(UserPhotosEndpoint, username);

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));
            AddQueryString(ref url, QueryParameter.OrderByQueryParameter, orderBy);
            AddQueryString(ref url, QueryParameter.StatsQueryParameter, stats);
            AddQueryString(ref url, QueryParameter.QuantityQueryParameter, CheckQuantityValue(quantity));

            if (orientation != Orientation.All)
            {
                AddQueryString(ref url, QueryParameter.OrientationQueryParameter, orientation);
            }

            List<Photo> photos = await GetAsync<List<Photo>>(url);
            return photos;
        }

        /// <inheritdoc/>
        public async Task<List<Photo>> GetUserLikedPhotosAsync(
            string username, 
            int page = 1,
            int perPage = 10, 
            PhotoOrderBy orderBy = PhotoOrderBy.Latest,
            Orientation orientation = Orientation.All)
        {

            string url = GetEndpointUrl(UserLikesEndpoint, username);

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));
            AddQueryString(ref url, QueryParameter.OrderByQueryParameter, orderBy);

            if (orientation != Orientation.All)
            {
                AddQueryString(ref url, QueryParameter.OrientationQueryParameter, orientation);
            }

            List<Photo> photos = await GetAsync<List<Photo>>(url);
            return photos;
        }

        /// <inheritdoc/>
        public async Task<List<Collection>> GetUserCollectionsAsync(
            string username, 
            int page = 1, 
            int perPage = 10)
        {
            string url = GetEndpointUrl(UserCollectionsEndpoint, username);

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));

            List<Collection> collections = await GetAsync<List<Collection>>(url);
            return collections;
        }

        /// <inheritdoc/>
        public async Task<UserStats> GetUserStatsAsync(
            string username,
            int quantity = 30)
        {

            string url = GetEndpointUrl(UserStatsEndpoint, username);

            AddQueryString(ref url, QueryParameter.ResolutionQueryParameter, QueryParameterValue.DaysResolutionQueryParameterValue);
            AddQueryString(ref url, QueryParameter.QuantityQueryParameter, CheckQuantityValue(quantity));

            UserStats userStats = await GetAsync<UserStats>(url);
            return userStats;
        }
    }
}
