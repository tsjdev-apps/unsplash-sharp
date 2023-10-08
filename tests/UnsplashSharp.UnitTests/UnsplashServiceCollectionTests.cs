using UnsplashSharp.Models;
using UnsplashSharp.UnitTests.Helpers;

namespace UnsplashSharp.UnitTests;

public class UnsplashServiceCollectionTests
{
    [Fact]
    public async Task GetCollectionsTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);
        
        // ACT
        List<Collection> collections = await service.GetCollectionsAsync();
        List<Collection> collectionsPaged = await service.GetCollectionsAsync(2);

        // ASSERT
        Assert.NotNull(collections);
        Assert.NotNull(collections.First().Id);
        Assert.NotNull(collectionsPaged);
        Assert.NotNull(collectionsPaged.First().Id);
    }

    [Fact]
    public async Task GetCollectionTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        Collection collection = await service.GetCollectionAsync("8240068");
        
        // ASSERT
        Assert.NotNull(collection);
    }

    [Fact]
    public async Task GetPhotosOfCollectionTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        List<Photo> photos = await service.GetPhotosOfCollectionAsync("8240068");

        // ASSERT
        Assert.NotNull(photos);
        Assert.True(photos.Count > 0);
    }

    [Fact]
    public async Task GetRelatedCollectionsTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        List<Collection> relatedCollections = await service.GetRelatedCollectionsAsync("8240068");

        // ASSERT
        Assert.NotNull(relatedCollections);
        Assert.True(relatedCollections.Count > 0);
    }
}
