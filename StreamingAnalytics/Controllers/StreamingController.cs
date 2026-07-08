using Microsoft.AspNetCore.Mvc;
using StreamingAnalytics.Services;

namespace StreamingAnalytics.Controllers
{
    // 📌 NE YAPAR?
    // Listeleme sayfasını yönetir.
    // Filtre parametrelerini alır, Sorgu 11 ve 12'yi çalıştırır.

    public class StreamingController : Controller
    {
        private readonly StreamingService _service;

        public StreamingController(StreamingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(
            string? userName,
            string? contentTitle,
            string? genre,
            string? platform,
            string? status,
            int page = 1)
        {
            int pageSize = 12;

            // Sorgu 11: Sayfalı + Filtreli liste
            var logs = await _service.GetPagedLogsAsync(
                page, pageSize, userName, contentTitle, genre, platform, status);

            // Sorgu 12: Toplam kayıt sayısı
            var totalCount = await _service.GetTotalCountAsync(
                userName, contentTitle, genre, platform, status);

            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // Filtre değerlerini view'a gönder
            ViewBag.CurrentPage   = page;
            ViewBag.TotalPages    = totalPages;
            ViewBag.TotalCount    = totalCount;
            ViewBag.UserName      = userName;
            ViewBag.ContentTitle  = contentTitle;
            ViewBag.Genre         = genre;
            ViewBag.Platform      = platform;
            ViewBag.Status        = status;

            return View(logs);
        }
    }
}
