using UnsplashSharp.Models;
using UnsplashSharp.UnitTests.Helpers;

namespace UnsplashSharp.UnitTests;

public class UnsplashServiceSearchTests
{
    [Fact]
    public async Task SearchPhotosTest()
    {
        // ARRANGE
        string query = "dogs";
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        List<Photo> photos = await service.SearchPhotosAsync(query);
        List<Photo> photosPaged = await service.SearchPhotosAsync(query, 2);

        // ASSERT
        Assert.True(photos.Count > 0);
        Assert.True(photosPaged.Count > 0);
    }

    [Fact]
    public async Task SearchCollectionsTest()
    {
        // ARRANGE
        string query = "dogs";
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        List<Collection> collections = await service.SearchCollectionsAsync(query);
        List<Collection> collectionsPaged = await service.SearchCollectionsAsync(query, 2);

        // ASSERT
        Assert.True(collections.Count > 0);
        Assert.True(collectionsPaged.Count > 0);
    }

    [Fact]
    public async Task SearchUsersTest()
    {
        // ARRANGE
        string query = "dogs";
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        List<User> users = await service.SearchUsersAsync(query);
        List<User> usersPaged = await service.SearchUsersAsync(query, 2);

        // ASSERT
        Assert.True(users.Count > 0);
        Assert.True(usersPaged.Count > 0);
    }
}
