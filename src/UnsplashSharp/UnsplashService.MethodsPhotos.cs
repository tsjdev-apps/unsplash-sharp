using System.Collections.Generic;
using System.Threading.Tasks;
using UnsplashSharp.Extensions;
using UnsplashSharp.Models;
using UnsplashSharp.Models.Enums;
using UnsplashSharp.Models.Helpers;

namespace UnsplashSharp
{
    public partial class UnsplashService
    {
        /// <inheritdoc/>
        public async Task<Photo> GetPhotoAsync(
            string id)
        {
            string url = GetEndpointUrl(PhotoEndpoint, id);

            Photo photo = await GetAsync<Photo>(url);
            return photo;
        }

        /// <inheritdoc/>
        public async Task<List<Photo>> GetRandomPhotosAsync(
            int count = 1,
            string[] collections = null,
            string[] topics = null,
            string username = "",
            string query = "",
            Orientation orientation = Orientation.All,
            ContentFilter contentFilter = ContentFilter.Low)
        {
            string url = GetEndpointUrl(RandomPhotosEndpoint);

            AddQueryString(ref url, QueryParameter.CountQueryParameter, count);

            if (collections != null)
            {
                AddQueryString(ref url, QueryParameter.CollectionsQueryParameter, string.Join(",", collections));
            }

            if (topics != null)
            {
                AddQueryString(ref url, QueryParameter.TopicsQueryParameter, string.Join(",", topics));
            }

            if (username.IsNeitherNullNorEmpty())
            {
                AddQueryString(ref url, QueryParameter.UsernameQueryParameter, username);
            }

            if (query.IsNeitherNullNorEmpty())
            {
                AddQueryString(ref url, QueryParameter.QueryQueryParameter, query);
            }

            if (orientation != Orientation.All)
            {
                AddQueryString(ref url, QueryParameter.OrientationQueryParameter, orientation);
            }

            AddQueryString(ref url, QueryParameter.ContentFilterQueryParameter, contentFilter);

            List<Photo> photos = await GetAsync<List<Photo>>(url);
            return photos;
        }

        /// <inheritdoc/>
        public async Task<PhotoStats> GetPhotoStatsAsync(
            string id,
            int quantity = 30)
        {
            string url = GetEndpointUrl(PhotoStatsEndpoint, id);

            AddQueryString(ref url, QueryParameter.ResolutionQueryParameter, QueryParameterValue.DaysResolutionQueryParameterValue);
            AddQueryString(ref url, QueryParameter.QuantityQueryParameter, CheckQuantityValue(quantity));

            PhotoStats photoStats = await GetAsync<PhotoStats>(url);
            return photoStats;
        }

        /// <inheritdoc/>
        public async Task<string> GetPhotoDownloadLinkAsync(
            string id)
        {
            string url = GetEndpointUrl(PhotoDownloadEndpoint, id);

            UrlInfo photoUrlInfo = await GetAsync<UrlInfo>(url);
            string photoUrl = photoUrlInfo.Url;
            return photoUrl;
        }

        /// <inheritdoc/>
        public async Task<List<Photo>> GetPhotosAsync(
            int page = 1,
            int perPage = 10,
            PhotoOrderBy orderBy = PhotoOrderBy.Latest)
        {
            string url = GetEndpointUrl(PhotosEndpoint);

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));
            AddQueryString(ref url, QueryParameter.OrderByQueryParameter, orderBy);

            List<Photo> photos = await GetAsync<List<Photo>>(url);
            return photos;
        }
    }
}
