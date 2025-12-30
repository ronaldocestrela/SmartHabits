using System.Security.Cryptography;
using System.Text;
using SmartHabit.Client.Models;

namespace SmartHabit.Client.Services
{
    public class AuthService(IMockApiService api) : IAuthService
    {
        private readonly IMockApiService _api = api;
        private User? _current;

        private static string Hash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _api.GetUserByEmailAsync(email);
            if (user == null) return null;
            var hash = Hash(password);
            if (user.PasswordHash != hash) return null;
            _current = user;
            return user;
        }

        public async Task<User?> RegisterAsync(User user, string password)
        {
            // simple password policy
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8) return null;
            // check uppercase, lowercase, digit and special
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit) || !password.Any(ch => !char.IsLetterOrDigit(ch))) return null;

            var existing = await _api.GetUserByEmailAsync(user.Email);
            if (existing != null) return null;
            user.PasswordHash = Hash(password);
            await _api.AddUserAsync(user);
            _current = user;
            return user;
        }

        public Task LogoutAsync()
        {
            _current = null;
            return Task.CompletedTask;
        }

        public Task<User?> GetCurrentUserAsync() => Task.FromResult(_current);
    }
}