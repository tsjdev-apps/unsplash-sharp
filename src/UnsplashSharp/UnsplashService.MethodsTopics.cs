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
        public async Task<List<Topic>> GetTopicsAsync(
            string[] ids = null,
            int page = 1,
            int perPage = 10,
            TopicOrderBy orderBy = TopicOrderBy.Position)
        {
            string url = GetEndpointUrl(TopicsEndpoint);

            if (ids != null)
            {
                AddQueryString(ref url, QueryParameter.IdsQueryParameter, string.Join(",", ids));
            }

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));
            AddQueryString(ref url, QueryParameter.OrderByQueryParameter,orderBy);

            List<Topic> topics = await GetAsync<List<Topic>>(url);
            return topics;
        }

        /// <inheritdoc/>
        public async Task<Topic> GetTopicAsync(
            string id)
        {
            string url = GetEndpointUrl(TopicEndpoint, id);

            Topic topic = await GetAsync<Topic>(url);
            return topic;
        }

        /// <inheritdoc/>
        public async Task<List<Photo>> GetPhotosOfTopicAsync(
            string id,
            int page = 1,
            int perPage = 10,
            Orientation orientation = Orientation.All,
            PhotoOrderBy orderBy = PhotoOrderBy.Latest)
        {
            string url = GetEndpointUrl(TopicPhotosEndpoint, id);

            AddQueryString(ref url, QueryParameter.PageQueryParameter, CheckPageValue(page));
            AddQueryString(ref url, QueryParameter.PerPageQueryParameter, CheckPerPageValue(perPage));

            if (orientation != Orientation.All)
            {
                AddQueryString(ref url, QueryParameter.OrientationQueryParameter, orientation);
            }

            AddQueryString(ref url, QueryParameter.OrderByQueryParameter, orderBy);

            List<Photo> photos = await GetAsync<List<Photo>>(url);
            return photos;
        }
    }
}
