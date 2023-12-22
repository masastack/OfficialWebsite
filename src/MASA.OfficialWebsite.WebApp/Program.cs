using Masa.Blazor;
using MASA.OfficialWebsite.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents()
       .AddHubOptions(options =>
       {
           options.MaximumReceiveMessageSize = 36 * 1024;
       });

builder.Services.AddMasaBlazor(options =>
{
    options.ConfigureSsr();
    options.ConfigureTheme(theme => { theme.Themes.Light.Primary = "#4318ff"; });
    options.ConfigureBreakpoint(breakpoint => { breakpoint.MobileBreakpoint = Breakpoints.Sm; });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
