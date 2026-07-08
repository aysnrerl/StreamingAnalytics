namespace StreamingAnalytics.Dtos
{
    // Dashboard sayfasındaki TÜM verileri bir arada tutar
    // Controller bu sınıfı View'a gönderir

    public class DashboardViewModel
    {
        // 4 Kart (Sorgu 1-4)
        public DashboardStatsDto Stats { get; set; } = new();

        // Sorgu 5: Aylık trend grafiği
        public List<ChartItemDto> MonthlyTrend { get; set; } = new();

        // Sorgu 6: Platform dağılımı (donut)
        public List<ChartItemDto> PlatformDist { get; set; } = new();

        // Sorgu 7: Tür dağılımı (bar)
        public List<ChartItemDto> GenreDist { get; set; } = new();

        // Sorgu 8: Cihaz dağılımı (pie)
        public List<ChartItemDto> DeviceDist { get; set; } = new();

        // Sorgu 9: Ülke dağılımı (Top 5 Ülke)
        public List<ChartItemDto> CountryDist { get; set; } = new();

        // Sorgu 10: Saatlik izlenme dağılımı
        public List<ChartItemDto> HourlyDist { get; set; } = new();

        // Sorgu 11: En çok izlenen 10 içerik
        public List<ChartItemDto> Top10Content { get; set; } = new();

        // Sorgu 12: Son 10 izleme kaydı
        public List<StreamingLogDto> RecentLogs { get; set; } = new();
    }
}
