using UnsplashSharp.Models;
using UnsplashSharp.Models.Enums;
using UnsplashSharp.UnitTests.Helpers;

namespace UnsplashSharp.UnitTests;

public class UnsplashServicePhotosTests
{
    [Fact]
    public async Task GetPhotoTest()
    {
        // ARRANGE
        string id = "VWl6oISA0RA";
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        Photo photo = await service.GetPhotoAsync(id);

        // ASSERT
        Assert.NotNull(photo);
        Assert.True(photo.Id == id);
    }

    [Fact]
    public async Task GetRandomPhotosTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        List<Photo> randomPhoto = await service.GetRandomPhotosAsync();
        List<Photo> randomPhotoFromCollection = await service.GetRandomPhotosAsync(collections: new string[] { "499830" });
        List<Photo> randomPhotoFromCollections = await service.GetRandomPhotosAsync(collections: new string[] { "499830", "194162" });
        List<Photo> randomPhotoFromUser = await service.GetRandomPhotosAsync(1, username: "chrisjoelcampbell");
        List<Photo> randomPhotosFromQuery = await service.GetRandomPhotosAsync(count: 3, query: "woman");
        List<Photo> randomPortraitPhoto = await service.GetRandomPhotosAsync(orientation: Orientation.Portrait);

        // ASSERT
        Assert.NotNull(randomPhoto);
        Assert.NotNull(randomPhotoFromCollection);
        Assert.NotNull(randomPhotoFromCollections);
        Assert.Single(randomPhotoFromUser);
        Assert.Equal(3, randomPhotosFromQuery.Count);
        Assert.Single(randomPortraitPhoto);
    }

    [Fact]
    public async Task GetPhotosTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        List<Photo> photos = await service.GetPhotosAsync();
        List<Photo> photosPaged = await service.GetPhotosAsync(page: 2, perPage: 15, orderBy: PhotoOrderBy.Popular);

        // ASSERT
        Assert.NotNull(photos);
        Assert.NotNull(photosPaged);
        Assert.True(photos.Count > 0);
        Assert.True(photosPaged.Count > 0);
    }

    [Fact]
    public async Task GetPhotoStatsTest()
    {
        // ARRANGE
        string id = "VWl6oISA0RA";
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        PhotoStats statsPhoto = await service.GetPhotoStatsAsync(id);

        // ASSERT
        Assert.NotNull(statsPhoto);
        Assert.True(statsPhoto.Id == id);
        Assert.NotNull(statsPhoto.Slug);
        Assert.NotNull(statsPhoto.DownloadInfo);
        Assert.NotNull(statsPhoto.Views);
        Assert.NotNull(statsPhoto.Likes);
    }

    [Fact]
    public async Task GetPhotoDownloadLinkTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);
        
        // ACT
        string downloadLink = await service.GetPhotoDownloadLinkAsync("VWl6oISA0RA");

        // ASSERT
        Assert.NotNull(downloadLink);
    }
}
