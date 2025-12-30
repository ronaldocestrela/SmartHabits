using Microsoft.JSInterop;

namespace SmartHabit.Client.Services
{
    public class ThemeService(IJSRuntime js) : IThemeService
    {
        private readonly IJSRuntime _js = js;
        private const string Key = "smarthabit_theme_dark";
        public event Action? ThemeChanged;

        public async Task<bool> IsDarkAsync()
        {
            try
            {
                var value = await _js.InvokeAsync<string>("localStorage.getItem", Key);
                if (bool.TryParse(value, out var result)) 
                    return result;
                return true; // default dark theme
            }
            catch
            {
                return true; // fallback to dark theme
            }
        }

        public async Task SetDarkAsync(bool isDark)
        {
            try
            {
                await _js.InvokeVoidAsync("localStorage.setItem", Key, isDark.ToString());
                await ApplyThemeAsync(isDark);
                ThemeChanged?.Invoke();
            }
            catch
            {
                // Handle JS interop errors silently
            }
        }

        public async Task InitializeThemeAsync()
        {
            try
            {
                var isDark = await IsDarkAsync();
                await ApplyThemeAsync(isDark);
            }
            catch
            {
                // Handle initialization errors silently
            }
        }

        private async Task ApplyThemeAsync(bool isDark)
        {
            try
            {
                var theme = isDark ? "dark" : "light";
                await _js.InvokeVoidAsync("eval", $"document.documentElement.setAttribute('data-theme', '{theme}')");
            }
            catch
            {
                // Handle JS errors silently
            }
        }
    }
}