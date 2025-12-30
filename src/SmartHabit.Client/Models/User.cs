namespace SmartHabit.Client.Models
{
    public class User
    {
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // For mock only
        public string? PhotoUrl { get; set; }
    }
}