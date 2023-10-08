using System.Collections.Generic;
using System.Threading.Tasks;
using UnsplashSharp.Models;
using UnsplashSharp.Models.Enums;

namespace UnsplashSharp
{
    public interface IUnsplashService
    {
        /// <summary>
        ///     The application ID provided by Unsplash.
        /// </summary>
        string ApplicationId { get; }

        /// <summary>
        ///     The maximum request limit for the client.
        /// </summary>
        int MaxRateLimit { get; }

        /// <summary>
        ///     The number of remaining requests the client can make.
        /// </summary>
        int RateLimitRemaining { get; }

        /// <summary>
        ///     Gets a list of photo collections.
        /// </summary>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <returns>A list of <see cref="Collection"/> objects.</returns>
        Task<Collection> GetCollectionAsync(string id);

        /// <summary>
        ///     Get a single photo collection.
        /// </summary>
        /// <param name="id">Unique id of the collection.</param>
        /// <returns>A <see cref="Collection"/> object representing the requested photo collection.</returns
        Task<List<Collection>> GetCollectionsAsync(int page = 1, int perPage = 10);

        /// <summary>
        ///     Gets a list of photos from a specific collection.
        /// </summary>
        /// <param name="id">Unique id of the collection.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <param name="orientation">Filter photos by orientation.</param>
        /// <returns>A list of <see cref="Photo"/> objects from the requested collection.</returns>
        Task<List<Photo>> GetPhotosOfCollectionAsync(string id, int page = 1, int perPage = 10, Orientation orientation = Orientation.All);

        /// <summary>
        ///     Gets a list of collections related to a specific collection.
        /// </summary>
        /// <param name="id">Unique id of the collection.</param>
        /// <returns>A list of related <see cref="Collection"/> objects.</returns>
        Task<List<Collection>> GetRelatedCollectionsAsync(string id);


        /// <summary>
        ///     Retrieves the total statistics object from Unsplash.
        /// </summary>
        /// <returns>The <see cref="TotalStats"/> object.</returns>
        Task<TotalStats> GetTotalStatsAsync();

        /// <summary>
        ///     Retrieves the monthly statistics object from Unsplash.
        /// </summary>
        /// <returns>The <see cref="MonthlyStats"/> object.</returns>
        Task<MonthlyStats> GetMonthlyStatsAsync();


        /// <summary>
        ///     Gets a single photo.
        /// </summary>
        /// <param name="id">Unique id of the photo.</param>
        /// <returns>A <see cref="Photo"/> object representing the requested photo.</returns>
        Task<Photo> GetPhotoAsync(string id);

        /// <summary>
        ///     Gets a list of random photos.
        /// </summary>
        /// <param name="count">Number of photos to retrieve. Maximum is 30. Default is 1.</param>
        /// <param name="collections">Filter photos by one or more collection IDs.</param>
        /// <param name="topics">Filter photos by one or more topic IDs.</param>
        /// <param name="username">Filter photos by a specific user's username.</param>
        /// <param name="query">Filter photos by a keyword search.</param>
        /// <param name="orientation">Filter photos by orientation.</param>
        /// <param name="contentFilter">Filter photos by content safety.</param>
        /// <returns>A list of <see cref="Photo"/> objects.</returns>
        Task<List<Photo>> GetRandomPhotosAsync(int count = 1, string[] collections = null, string[] topics = null, string username = "", string query = "", Orientation orientation = Orientation.All, ContentFilter contentFilter = ContentFilter.Low);

        /// <summary>
        ///     Gets statistics for a specific photo.
        /// </summary>
        /// <param name="id">Unique id of the photo.</param>
        /// <param name="quantity">Number of days to retrieve statistics for. Maximum is 30. Default is 30.</param>
        /// <returns>A <see cref="PhotoStats"/> object reprenseting the requested photo's statistics.</returns>
        Task<PhotoStats> GetPhotoStatsAsync(string id, int quantity = 30);

        /// <summary>
        ///     Gets a download link for a specific photo.
        /// </summary>
        /// <param name="id">Unique id of the photo.</param>
        /// <returns>A download URL string for the requested photo.</returns>
        Task<string> GetPhotoDownloadLinkAsync(string id);

        /// <summary>
        ///     Gets a list of photos.
        /// </summary>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <param name="orderBy">Sort photos by a specific order.</param>
        /// <returns>A list of <see cref="Photo"/> objects.</returns>
        Task<List<Photo>> GetPhotosAsync(int page = 1, int perPage = 10, PhotoOrderBy orderBy = PhotoOrderBy.Latest);


        /// <summary>
        ///     Searches for photos on Unsplash based on the given query string and search parameters.
        /// </summary>
        /// <param name="query">The query string to search for.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <param name="orderBy">Sort photos by a specific order.</param>
        /// <param name="collectionIds">Filter photos by one or more collection IDs.</param>
        /// <param name="contentFilter">Filter photos by content safety.</param>
        /// <param name="color">Filter results based on color.</param>
        /// <param name="orientation">Filter results based on orientation.</param>
        /// <returns>A list of <see cref="Photo"/> objects matching the search criteria.</returns>
        Task<List<Photo>> SearchPhotosAsync(string query, int page = 1, int perPage = 10, PhotoOrderBy orderBy = PhotoOrderBy.Latest, string[] collectionIds = null, ContentFilter contentFilter = ContentFilter.Low, UnsplashColor color = UnsplashColor.All, Orientation orientation = Orientation.All);

        /// <summary>
        ///     Searches for collections on Unsplash based on the given query string and search parameters. 
        /// </summary>
        /// <param name="query">The query string to search for.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <returns>A list of <see cref="Collection"/> objects matching the search criteria.</returns>
        Task<List<Collection>> SearchCollectionsAsync(string query, int page = 1, int perPage = 10);

        /// <summary>
        /// Searches for users on Unsplash based on the given query string and search parameters.
        /// </summary>
        /// <param name="query">The query string to search for.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <returns>A list of <see cref="User"/> objects matching the search criteria.</returns>
        Task<List<User>> SearchUsersAsync(string query, int page = 1, int perPage = 10);


        /// <summary>
        ///     Retrieves a list of topics from Unsplash, filtered by ID and sorted by position, with pagination.
        /// </summary>
        /// <param name="ids">An array of topic IDs to filter by.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <param name="orderBy">The sort order for results.</param>
        /// <returns>A list of <see cref="Topic"/> objects matching the filtering and sorting criteria.</returns>
        Task<List<Topic>> GetTopicsAsync(string[] ids = null, int page = 1, int perPage = 10, TopicOrderBy orderBy = TopicOrderBy.Position);

        /// <summary>
        ///     Retrieves a topic from Unsplash by ID.
        /// </summary>
        /// <param name="id">Unique ID of the topic to retrieve.</param>
        /// <returns>A <see cref="Topic"/> object with the specified ID.</returns>
        Task<Topic> GetTopicAsync(string id);

        /// <summary>
        ///     Retrieves a list of photos from Unsplash related to a given topic ID.
        /// </summary>
        /// <param name="id">Unique ID of the topic to retrieve photos for.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <param name="orientation">The orientation of the photo.</param>
        /// <param name="orderBy">The sort order for results.</param>
        /// <returns>A list of <see cref="Photo"/> objects related to the given topic ID.</returns>
        Task<List<Photo>> GetPhotosOfTopicAsync(string id, int page = 1, int perPage = 10, Orientation orientation = Orientation.All, PhotoOrderBy orderBy = PhotoOrderBy.Latest);


        /// <summary>
        ///     Retrieves a user object from Unsplash by username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>A <see cref="User"/> object with the specified username.</returns>
        Task<User> GetUserAsync(string username);

        /// <summary>
        ///     Retrieves the portfolio link of a user with the specified username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve the portfolio link for.</param>
        /// <returns>The portfolio link of the specified user.</returns>
        Task<string> GetUserPorfolioLinkAsync(string username);

        /// <summary>
        ///     Retrieves a list of photos uploaded by a user with the specified username. 
        /// </summary>
        /// <param name="username">The username of the user to retrieve photos from.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <param name="orderBy">The sort order for results.</param>
        /// <param name="stats">Whether or not to include statistics for the photos.</param>
        /// <param name="quantity">The number of statistics to include.</param>
        /// <param name="orientation">The orientation of the photos to return.</param>
        /// <returns>A list of <see cref="Photo"/> objects uploaded by the specified user.</returns>
        Task<List<Photo>> GetUserPhotosAsync(string username, int page = 1, int perPage = 10, PhotoOrderBy orderBy = PhotoOrderBy.Latest, bool stats = false, int quantity = 30, Orientation orientation = Orientation.All);

        /// <summary>
        ///     Retrieves a list of photos liked by a user with the specified username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve liked photos for.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <param name="orderBy">The sort order for results.</param>
        /// <param name="orientation">The orientation of the photos to return.</param>
        /// <returns>A list of <see cref="Photo"/> objects liked by the specified user.</returns>
        Task<List<Photo>> GetUserLikedPhotosAsync(string username, int page = 1, int perPage = 10, PhotoOrderBy orderBy = PhotoOrderBy.Latest, Orientation orientation = Orientation.All);

        /// <summary>
        ///     Retrieves a list of collections created by a user with the specified username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve collections for.</param>
        /// <param name="page">Page number to retrieve. Default is 1.</param>
        /// <param name="perPage">Number of items to retrieve per page. Maximum is 30. Default is 10.</param>
        /// <returns>A list of <see cref="Collection"/> objects created by the specified user.</returns>
        Task<List<Collection>> GetUserCollectionsAsync(string username, int page = 1, int perPage = 10);

        /// <summary>
        ///     Retrieves statistics for a user with the specified username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve statistics for.</param>
        /// <param name="quantity">The number of statistics to include.</param>
        /// <returns>A <see cref="UserStats"/> object with the specified statistics.</returns>
        Task<UserStats> GetUserStatsAsync(string username, int quantity = 30);
    }
}