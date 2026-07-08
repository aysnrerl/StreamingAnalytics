using Dapper;
using StreamingAnalytics.Context;
using StreamingAnalytics.Dtos;

namespace StreamingAnalytics.Services
{
    // 📌 NE YAPAR?
    // Tüm SQL sorgularını buraya yazıyoruz.
    // Controller "bana veriyi getir" der → Service SQL'i çalıştırır → Sonucu döndürür.

    public class StreamingService
    {
        private readonly DapperContext _context;

        public StreamingService(DapperContext context)
        {
            _context = context;
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 1 — Toplam izlenme sayısı (Kart)
        // ══════════════════════════════════════════════════════
        public async Task<long> GetTotalWatchCountAsync()
        {
            using var db = _context.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<long>(
                "SELECT COUNT(*) FROM StreamingLogs");
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 2 — Toplam tekil kullanıcı sayısı (Kart)
        // ══════════════════════════════════════════════════════
        public async Task<long> GetTotalUniqueUsersAsync()
        {
            using var db = _context.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<long>(
                "SELECT COUNT(DISTINCT UserName) FROM StreamingLogs");
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 3 — Toplam izlenme saati (Kart)
        // ══════════════════════════════════════════════════════
        public async Task<long> GetTotalWatchHoursAsync()
        {
            using var db = _context.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<long>(
                "SELECT SUM(WatchDurationMin) / 60 FROM StreamingLogs");
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 4 — Ortalama puan (Kart)
        // ══════════════════════════════════════════════════════
        public async Task<decimal> GetAverageRatingAsync()
        {
            using var db = _context.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<decimal>(
                "SELECT ROUND(AVG(CAST(Rating AS FLOAT)), 1) FROM StreamingLogs");
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 5 — Aylık izlenme trendi (Bar Grafik)
        // ══════════════════════════════════════════════════════
        public async Task<List<ChartItemDto>> GetMonthlyTrendAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT 
                    FORMAT(WatchDate, 'yyyy-MM') AS Label,
                    COUNT(*) AS Value
                FROM StreamingLogs
                WHERE WatchDate >= DATEADD(MONTH, -12, GETDATE())
                GROUP BY FORMAT(WatchDate, 'yyyy-MM')
                ORDER BY Label";
            var result = await db.QueryAsync<ChartItemDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 6 — Platform dağılımı (Donut Grafik)
        // ══════════════════════════════════════════════════════
        public async Task<List<ChartItemDto>> GetPlatformDistributionAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT Platform AS Label, COUNT(*) AS Value
                FROM StreamingLogs
                GROUP BY Platform
                ORDER BY Value DESC";
            var result = await db.QueryAsync<ChartItemDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 7 — Tür dağılımı (Bar Grafik)
        // ══════════════════════════════════════════════════════
        public async Task<List<ChartItemDto>> GetGenreDistributionAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT Genre AS Label, COUNT(*) AS Value
                FROM StreamingLogs
                GROUP BY Genre
                ORDER BY Value DESC";
            var result = await db.QueryAsync<ChartItemDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 8 — Cihaz türü dağılımı (Pie Grafik)
        // ══════════════════════════════════════════════════════
        public async Task<List<ChartItemDto>> GetDeviceDistributionAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT DeviceType AS Label, COUNT(*) AS Value
                FROM StreamingLogs
                GROUP BY DeviceType
                ORDER BY Value DESC";
            var result = await db.QueryAsync<ChartItemDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 9 — Ülkelere göre izlenme dağılımı (Top 5 Ülke)
        // ══════════════════════════════════════════════════════
        public async Task<List<ChartItemDto>> GetCountryDistributionAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT TOP 5 Country AS Label, COUNT(*) AS Value
                FROM StreamingLogs
                GROUP BY Country
                ORDER BY Value DESC";
            var result = await db.QueryAsync<ChartItemDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 10 — Saatlik izlenme dağılımı (Çizgi Grafik)
        // ══════════════════════════════════════════════════════
        public async Task<List<ChartItemDto>> GetHourlyDistributionAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT 
                    RIGHT('0' + CAST(DATEPART(HOUR, WatchDate) AS VARCHAR), 2) + ':00' AS Label, 
                    COUNT(*) AS Value
                FROM StreamingLogs
                GROUP BY DATEPART(HOUR, WatchDate)
                ORDER BY DATEPART(HOUR, WatchDate)";
            var result = await db.QueryAsync<ChartItemDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 11 — En çok izlenen 10 içerik (Tablo)
        // ══════════════════════════════════════════════════════
        public async Task<List<ChartItemDto>> GetTop10ContentAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT TOP 10 ContentTitle AS Label, COUNT(*) AS Value
                FROM StreamingLogs
                GROUP BY ContentTitle
                ORDER BY Value DESC";
            var result = await db.QueryAsync<ChartItemDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 12 — Son 10 izleme kaydı (Hızlı Bakış Tablosu)
        // ══════════════════════════════════════════════════════
        public async Task<List<StreamingLogDto>> GetRecentLogsAsync()
        {
            using var db = _context.CreateConnection();
            var sql = @"
                SELECT TOP 10
                    LogId, UserName, ContentTitle, Genre, Platform,
                    WatchDate, WatchDurationMin, Rating, Country, DeviceType, Status
                FROM StreamingLogs
                ORDER BY LogId DESC";
            var result = await db.QueryAsync<StreamingLogDto>(sql);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 11 — Sayfalı + Filtreli listeleme
        // ══════════════════════════════════════════════════════
        public async Task<List<StreamingLogDto>> GetPagedLogsAsync(
            int page, int pageSize,
            string? userName, string? contentTitle,
            string? genre, string? platform, string? status)
        {
            using var db = _context.CreateConnection();

            var where = "WHERE 1=1";
            var p = new DynamicParameters();

            if (!string.IsNullOrEmpty(userName))
            {
                where += " AND UserName LIKE @UserName";
                p.Add("UserName", $"%{userName}%");
            }
            if (!string.IsNullOrEmpty(contentTitle))
            {
                where += " AND ContentTitle LIKE @ContentTitle";
                p.Add("ContentTitle", $"%{contentTitle}%");
            }
            if (!string.IsNullOrEmpty(genre))
            {
                where += " AND Genre = @Genre";
                p.Add("Genre", genre);
            }
            if (!string.IsNullOrEmpty(platform))
            {
                where += " AND Platform = @Platform";
                p.Add("Platform", platform);
            }
            if (!string.IsNullOrEmpty(status))
            {
                where += " AND Status = @Status";
                p.Add("Status", status);
            }

            p.Add("Offset", (page - 1) * pageSize);
            p.Add("PageSize", pageSize);

            var sql = $@"
                SELECT LogId, UserName, ContentTitle, Genre, Platform,
                       WatchDate, WatchDurationMin, Rating, Country, DeviceType, Status
                FROM StreamingLogs
                {where}
                ORDER BY LogId DESC
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var result = await db.QueryAsync<StreamingLogDto>(sql, p);
            return result.ToList();
        }

        // ══════════════════════════════════════════════════════
        //  SORGU 12 — Filtreye göre toplam kayıt sayısı (Paging)
        // ══════════════════════════════════════════════════════
        public async Task<int> GetTotalCountAsync(
            string? userName, string? contentTitle,
            string? genre, string? platform, string? status)
        {
            using var db = _context.CreateConnection();

            var where = "WHERE 1=1";
            var p = new DynamicParameters();

            if (!string.IsNullOrEmpty(userName))
            {
                where += " AND UserName LIKE @UserName";
                p.Add("UserName", $"%{userName}%");
            }
            if (!string.IsNullOrEmpty(contentTitle))
            {
                where += " AND ContentTitle LIKE @ContentTitle";
                p.Add("ContentTitle", $"%{contentTitle}%");
            }
            if (!string.IsNullOrEmpty(genre))
            {
                where += " AND Genre = @Genre";
                p.Add("Genre", genre);
            }
            if (!string.IsNullOrEmpty(platform))
            {
                where += " AND Platform = @Platform";
                p.Add("Platform", platform);
            }
            if (!string.IsNullOrEmpty(status))
            {
                where += " AND Status = @Status";
                p.Add("Status", status);
            }

            var sql = $"SELECT COUNT(*) FROM StreamingLogs {where}";
            return await db.QueryFirstOrDefaultAsync<int>(sql, p);
        }
    }
}
