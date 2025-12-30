using SmartHabit.Client.Models;

namespace SmartHabit.Client.Services
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string email, string password);
        Task<User?> RegisterAsync(User user, string password);
        Task LogoutAsync();
        Task<User?> GetCurrentUserAsync();
    }
}