namespace emz.Data
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string IpAddress { get; set; } = string.Empty;
    }
}