namespace emz.Data
{
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Activity { get; set; } = string.Empty;
    }
}