using System.Text.Json.Serialization;

namespace emz.Data
{
    public class UsersHeadquarters
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HeadquarterId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}