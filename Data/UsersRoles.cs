using System.Text.Json.Serialization;

namespace emz.Data
{
    public class UsersRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RolesId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}