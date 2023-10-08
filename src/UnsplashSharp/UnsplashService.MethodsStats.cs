using System.Threading.Tasks;
using UnsplashSharp.Models;

namespace UnsplashSharp
{
    public partial class UnsplashService
    {
        /// <inheritdoc/>
        public async Task<TotalStats> GetTotalStatsAsync()
        {
            string url = GetEndpointUrl(TotalStatsEndpoint);

            TotalStats totalStats = await GetAsync<TotalStats>(url);
            return totalStats;
        }

        /// <inheritdoc/>
        public async Task<MonthlyStats> GetMonthlyStatsAsync()
        {
            string url = GetEndpointUrl(MonthlyStatsEndpoint);

            MonthlyStats monthlyStats = await GetAsync<MonthlyStats>(url);
            return monthlyStats;
        }
    }
}
