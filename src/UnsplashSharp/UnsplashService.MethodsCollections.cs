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
        public async Task<List<Collection>> GetCollectionsAsync(
            int page = 1,
            int perPage = 10)
        {
            string url = GetEndpointUrl(CollectionEndpoint);

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));

            List<Collection> collections = await GetAsync<List<Collection>>(url);
            return collections;
        }

        /// <inheritdoc/>
        public async Task<Collection> GetCollectionAsync(
            string id)
        {
            string url = GetEndpointUrl(CollectionEndpoint, id);

            Collection collection = await GetAsync<Collection>(url);
            return collection;
        }

        /// <inheritdoc/>
        public async Task<List<Photo>> GetPhotosOfCollectionAsync(
            string id, 
            int page = 1, 
            int perPage = 10,
            Orientation orientation = Orientation.All)
        {
            string url = GetEndpointUrl(CollectionPhotosEndpoint, id);

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));

            if (orientation != Orientation.All)
            {
                AddQueryString(ref url, QueryParameter.OrientationQueryParameter, orientation);
            }

            List<Photo> photos = await GetAsync<List<Photo>>(url);
            return photos;
        }

        /// <inheritdoc/>
        public async Task<List<Collection>> GetRelatedCollectionsAsync(
            string id)
        {
            string url = GetEndpointUrl(CollectionsRelatedEndpoint, id);

            List<Collection> collections = await GetAsync<List<Collection>>(url);
            return collections;
        }
    }
}
