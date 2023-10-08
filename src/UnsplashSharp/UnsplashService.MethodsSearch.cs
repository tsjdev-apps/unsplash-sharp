using System.Collections.Generic;
using System.Threading.Tasks;
using UnsplashSharp.Models;
using UnsplashSharp.Models.Enums;
using UnsplashSharp.Models.Helpers;
using UnsplashSharp.Models.SearchResults;

namespace UnsplashSharp
{
    public partial class UnsplashService
    {
        /// <inheritdoc/>
        public async Task<List<Photo>> SearchPhotosAsync(
            string query,
            int page = 1,
            int perPage = 10,
            PhotoOrderBy orderBy = PhotoOrderBy.Latest,
            string[] collectionIds = null,
            ContentFilter contentFilter = ContentFilter.Low,
            UnsplashColor color = UnsplashColor.All,
            Orientation orientation = Orientation.All)
        {
            string url = GetEndpointUrl(SearchPhotosEndpoint);

            AddQueryString(ref url, QueryParameter.QueryQueryParameter, query);
            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));
            AddQueryString(ref url, QueryParameter.OrderByQueryParameter, orderBy);
            AddQueryString(ref url, QueryParameter.ContentFilterQueryParameter, contentFilter);

            if (collectionIds != null)
            {
                AddQueryString(ref url, QueryParameter.CollectionsQueryParameter, string.Join(",", collectionIds));
            }

            if (color != UnsplashColor.All)
            {
                AddQueryString(ref url, QueryParameter.ColorQueryParameter, GetColorParamter(color));
            }

            if (orientation != Orientation.All)
            {
                AddQueryString(ref url, QueryParameter.OrientationQueryParameter, orientation);
            }

            PhotoSearchResult photoResult = await GetAsync<PhotoSearchResult>(url);
            return photoResult.Photos;
        }

        /// <inheritdoc/>
        public async Task<List<Collection>> SearchCollectionsAsync(
            string query, 
            int page = 1, 
            int perPage = 10)
        {
            string url = GetEndpointUrl(SearchCollectionsEndpoint);

            AddQueryString(ref url, QueryParameter.QueryQueryParameter, query);
            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));

            CollectionSearchResult collectionResult = await GetAsync<CollectionSearchResult>(url);
            return collectionResult.Collections;
        }

        /// <inheritdoc/>
        public async Task<List<User>> SearchUsersAsync(
            string query, 
            int page = 1, 
            int perPage = 10)
        {
            string url = GetEndpointUrl(SearchUsersEndpoint);

            AddQueryString(ref url, QueryParameter.QueryQueryParameter, query);
            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));

            UserSearchResult userResult = await GetAsync<UserSearchResult>(url);
            return userResult.Users;
        }
    }
}
