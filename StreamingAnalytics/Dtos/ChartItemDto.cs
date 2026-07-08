namespace StreamingAnalytics.Dtos
{
    // Grafik ve liste sorgularında ortak kullanılır
    // Label = X ekseni (ay adı, platform adı, tür adı...)
    // Value = Y ekseni (sayı)

    public class ChartItemDto
    {
        public string Label { get; set; } = string.Empty;
        public long   Value { get; set; }
    }
}
