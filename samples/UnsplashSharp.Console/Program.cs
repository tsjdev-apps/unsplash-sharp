using Spectre.Console;
using UnsplashSharp;
using UnsplashSharp.Models;
using UnsplashSharp.Models.Enums;

AnsiConsole.Write(new FigletText("UnsplashSharp").LeftJustified().Color(Color.Red));

UnsplashService unsplashService = new("UNSPLASHAPIKEY");

// COLLECTIONS
List<Collection> getCollectionsResult = await unsplashService.GetCollectionsAsync();
Collection getCollectionResult = await unsplashService.GetCollectionAsync("8240068");
List<Photo> getPhotosOfCollectionResult = await unsplashService.GetPhotosOfCollectionAsync("8240068");
List<Collection> getRelatedCollectionsResult = await unsplashService.GetRelatedCollectionsAsync("8240068");

// PHOTOS
Photo getPhotoResult = await unsplashService.GetPhotoAsync("VWl6oISA0RA");
List<Photo> getRandomPhotosResult = await unsplashService.GetRandomPhotosAsync();
List<Photo> getRandomPhotosWithCollectionIdResult = await unsplashService.GetRandomPhotosAsync(collections: new string[] { "499830" });
List<Photo> getRandomPhotosWithMultipleCollectionIdsResult = await unsplashService.GetRandomPhotosAsync(collections: new string[] { "499830", "194162" });
List<Photo> getRandomPhotoWithUsernameResult = await unsplashService.GetRandomPhotosAsync(1, username: "tsjphoto");
List<Photo> getRandomPhotosWithQueryResult = await unsplashService.GetRandomPhotosAsync(5, query: "woman");
List<Photo> getRandomPhotosWithOrientationResult = await unsplashService.GetRandomPhotosAsync(orientation: Orientation.Portrait);
PhotoStats getPhotoStatsResult = await unsplashService.GetPhotoStatsAsync("VWl6oISA0RA");
string getPhotoDownloadLinkResult = await unsplashService.GetPhotoDownloadLinkAsync("VWl6oISA0RA");
List<Photo> getPhotosResult = await unsplashService.GetPhotosAsync();
List<Photo> getPhotosResultWithParametersResult = await unsplashService.GetPhotosAsync(page: 2, perPage: 15, orderBy: PhotoOrderBy.Popular);

// SEARCH
List<Photo> photoSearchResult = await unsplashService.SearchPhotosAsync("unsplash", contentFilter: ContentFilter.High, orientation: Orientation.Squarish, color: UnsplashColor.BlackAndWhite);
List<Collection> collectionSearchResult = await unsplashService.SearchCollectionsAsync("unsplash");
List<User> usersSearchResult = await unsplashService.SearchUsersAsync("tsjphoto");

// STATS
TotalStats getTotalStatsResult = await unsplashService.GetTotalStatsAsync();
MonthlyStats getMonthlyStatsResult = await unsplashService.GetMonthlyStatsAsync();

// TOPICS
List<Topic> getTopicsResult = await unsplashService.GetTopicsAsync();
Topic getTopicResult = await unsplashService.GetTopicAsync("3bnm95isIxE");
List<Photo> getPhotosOfTopicResult = await unsplashService.GetPhotosOfTopicAsync("3bnm95isIxE");

// USER
User getUserResult = await unsplashService.GetUserAsync("tsjphoto");
string getUserPortfolioLinkResult = await unsplashService.GetUserPorfolioLinkAsync("tsjphoto");
List<Photo> getPhotosOfUserResult = await unsplashService.GetUserPhotosAsync("tsjphoto");
List<Photo> getUserLikesResult = await unsplashService.GetUserLikedPhotosAsync("tsjphoto");
List<Collection> getUserCollectionsResult = await unsplashService.GetUserCollectionsAsync("tsjphoto");
UserStats getUserStats = await unsplashService.GetUserStatsAsync("tsjphoto");

Console.ReadLine();