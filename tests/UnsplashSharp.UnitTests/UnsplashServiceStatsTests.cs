using UnsplashSharp.Models;
using UnsplashSharp.UnitTests.Helpers;

namespace UnsplashSharp.UnitTests;

public class UnsplashServiceStatsTests
{
    [Fact]
    public async Task GetTotalStatsTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        TotalStats totalStats = await service.GetTotalStatsAsync();

        // ASSERT
        Assert.NotNull(totalStats);
        Assert.True(totalStats.TotalPhotos > 0);
        Assert.True(totalStats.PhotoDownloads > 0);
        Assert.True(totalStats.Photos > 0);
        Assert.True(totalStats.Downloads > 0);
        Assert.True(totalStats.Views > 0);
        Assert.True(totalStats.Photographers > 0);
        Assert.True(totalStats.Pixels > 0);
        Assert.True(totalStats.DownloadsPerSecond > 0);
        Assert.True(totalStats.ViewsPerSecond > 0);
        Assert.True(totalStats.Developers > 0);
        Assert.True(totalStats.Applications > 0);
        Assert.True(totalStats.Requests > 0);
    }

    [Fact]
    public async Task GetMonthlyStatsTest()
    {
        // ARRANGE
        UnsplashService service = new(Credentials.ApplicationId);

        // ACT
        MonthlyStats monthlyStats = await service.GetMonthlyStatsAsync();

        // ASSERT
        Assert.NotNull(monthlyStats);
        Assert.True(monthlyStats.Views > 0);
    }
}
