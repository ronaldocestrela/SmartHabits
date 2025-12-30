using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartHabit.Client;
using SmartHabit.Client.Services;
using SmartHabit.Client.State;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Application services
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMockApiService, MockApiService>();
builder.Services.AddScoped<IThemeService, ThemeService>();

await builder.Build().RunAsync();
