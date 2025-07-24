namespace OnlineStoreAuthAPI.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "Customer";
    }
}
