namespace emz.Data
{
    public class Token
    {
        public int Id { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}