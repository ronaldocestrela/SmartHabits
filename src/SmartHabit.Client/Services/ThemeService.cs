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
            var v = await _js.InvokeAsync<string>("localStorage.getItem", Key);
            if (bool.TryParse(v, out var res)) return res;
            return true; // default dark
        }

        public async Task SetDarkAsync(bool isDark)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", Key, isDark.ToString());
            ThemeChanged?.Invoke();
        }
    }
}