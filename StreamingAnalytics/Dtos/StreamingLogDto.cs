namespace StreamingAnalytics.Dtos
{
    // Son izlemeler tablosu ve listeleme sayfası için

    public class StreamingLogDto
    {
        public int    LogId            { get; set; }
        public string UserName         { get; set; } = string.Empty;
        public string ContentTitle     { get; set; } = string.Empty;
        public string Genre            { get; set; } = string.Empty;
        public string Platform         { get; set; } = string.Empty;
        public DateTime WatchDate      { get; set; }
        public int    WatchDurationMin { get; set; }
        public decimal Rating          { get; set; }
        public string Country          { get; set; } = string.Empty;
        public string DeviceType       { get; set; } = string.Empty;
        public string Status           { get; set; } = string.Empty;
    }
}
