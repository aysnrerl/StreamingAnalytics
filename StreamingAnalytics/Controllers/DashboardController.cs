using Microsoft.AspNetCore.Mvc;
using StreamingAnalytics.Dtos;
using StreamingAnalytics.Services;

namespace StreamingAnalytics.Controllers
{
    // 📌 NE YAPAR?
    // Dashboard sayfasını yönetir.
    // Service'den 10 sorgunun sonucunu alır, hepsini DashboardViewModel'e koyar,
    // View'a gönderir.

    public class DashboardController : Controller
    {
        private readonly StreamingService _service;

        public DashboardController(StreamingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            // Sorgu 1-4: Kartlar
            var totalWatch    = await _service.GetTotalWatchCountAsync();
            var totalUsers    = await _service.GetTotalUniqueUsersAsync();
            var totalHours    = await _service.GetTotalWatchHoursAsync();
            var avgRating     = await _service.GetAverageRatingAsync();

            // Sorgu 5-8: Grafikler
            var monthly       = await _service.GetMonthlyTrendAsync();
            var platform      = await _service.GetPlatformDistributionAsync();
            var genre         = await _service.GetGenreDistributionAsync();
            var device        = await _service.GetDeviceDistributionAsync();

            // Sorgu 9-10: Yeni Grafikler
            var country       = await _service.GetCountryDistributionAsync();
            var hourly        = await _service.GetHourlyDistributionAsync();

            // Sorgu 11-12: Tablolar
            var top10         = await _service.GetTop10ContentAsync();
            var recent        = await _service.GetRecentLogsAsync();

            // Hepsini ViewModel'e doldur
            var model = new DashboardViewModel
            {
                Stats = new DashboardStatsDto
                {
                    TotalWatchCount  = totalWatch,
                    TotalUniqueUsers = totalUsers,
                    TotalWatchHours  = totalHours,
                    AverageRating    = avgRating
                },
                MonthlyTrend = monthly,
                PlatformDist = platform,
                GenreDist    = genre,
                DeviceDist   = device,
                CountryDist  = country,
                HourlyDist   = hourly,
                Top10Content = top10,
                RecentLogs   = recent
            };

            return View(model);
        }

        public async Task<IActionResult> Charts(string section = "monthly")
        {
            // Tüm sorguları çalıştır
            var totalWatch    = await _service.GetTotalWatchCountAsync();
            var totalUsers    = await _service.GetTotalUniqueUsersAsync();
            var totalHours    = await _service.GetTotalWatchHoursAsync();
            var avgRating     = await _service.GetAverageRatingAsync();

            var monthly       = await _service.GetMonthlyTrendAsync();
            var platform      = await _service.GetPlatformDistributionAsync();
            var genre         = await _service.GetGenreDistributionAsync();
            var device        = await _service.GetDeviceDistributionAsync();
            var country       = await _service.GetCountryDistributionAsync();
            var hourly        = await _service.GetHourlyDistributionAsync();

            var top10         = await _service.GetTop10ContentAsync();
            var recent        = await _service.GetRecentLogsAsync();

            var model = new DashboardViewModel
            {
                Stats = new DashboardStatsDto
                {
                    TotalWatchCount  = totalWatch,
                    TotalUniqueUsers = totalUsers,
                    TotalWatchHours  = totalHours,
                    AverageRating    = avgRating
                },
                MonthlyTrend = monthly,
                PlatformDist = platform,
                GenreDist    = genre,
                DeviceDist   = device,
                CountryDist  = country,
                HourlyDist   = hourly,
                Top10Content = top10,
                RecentLogs   = recent
            };

            ViewBag.ActiveSection = section;
            return View(model);
        }
    }
}
