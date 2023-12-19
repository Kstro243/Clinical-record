namespace emz.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int TypeOfIdentificationId { get; set; }
        public string IdentificationNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<UsersRoles>? UsersRoles { get ; set; }
        public List<UsersHeadquarters>? UsersHeadquarters { get ; set; }
    }
}