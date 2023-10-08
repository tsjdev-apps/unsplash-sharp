using UnsplashSharp.UnitTests.Helpers;

namespace UnsplashSharp.UnitTests;

public class UnsplashServiceTests
{
    [Fact]
    public async Task RateLimitTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        _ = await service.GetRandomPhotosAsync();

        // ASSERT
        Assert.True(service.RateLimitRemaining < service.MaxRateLimit);
    }
}