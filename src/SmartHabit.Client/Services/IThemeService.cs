namespace SmartHabit.Client.Services
{
    public interface IThemeService
    {
        Task<bool> IsDarkAsync();
        Task SetDarkAsync(bool isDark);
        event Action? ThemeChanged;
    }
}