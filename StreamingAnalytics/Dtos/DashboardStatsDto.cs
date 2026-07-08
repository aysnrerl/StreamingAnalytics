namespace StreamingAnalytics.Dtos
{
    // 📌 NE YAPAR?
    // Dashboard'daki 4 kartın verilerini taşır.
    // Sorgu 1, 2, 3, 4 bu sınıfa doldurulur.

    public class DashboardStatsDto
    {
        public long   TotalWatchCount   { get; set; }  // Sorgu 1: Toplam izlenme
        public long   TotalUniqueUsers  { get; set; }  // Sorgu 2: Tekil kullanıcı
        public long   TotalWatchHours   { get; set; }  // Sorgu 3: Toplam saat
        public decimal AverageRating    { get; set; }  // Sorgu 4: Ortalama puan
    }
}
