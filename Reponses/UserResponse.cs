namespace emz.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TypeOfIdentificationName { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}