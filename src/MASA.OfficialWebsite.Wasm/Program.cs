using Masa.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMasaBlazor(options =>
{
    options.ConfigureTheme(theme => { theme.Themes.Light.Primary = "#4318ff"; });
    options.ConfigureBreakpoint(breakpoint => { breakpoint.MobileBreakpoint = Breakpoints.Sm; });
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
