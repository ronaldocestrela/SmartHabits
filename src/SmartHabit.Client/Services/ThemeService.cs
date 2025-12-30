using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SmartHabit.Client.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IJSRuntime _js;
        private const string Key = "smarthabit_theme_dark";
        public event System.Action? ThemeChanged;

        public ThemeService(IJSRuntime js)
        {
            _js = js;
        }

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