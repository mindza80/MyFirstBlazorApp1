using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyFirstBlazorApp;
using MyFirstBlazorApp.Authentification;
using MyFirstBlazorApp.Authentification.Contracts;
using MyFirstBlazorApp.Database;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<AuthenticationStateProvider, TokenAuthenticationStateProviderServise>();
builder.Services.AddSingleton<ICryptographyServise, CryptographyServise>(x => new CryptographyServise(builder.Configuration.GetValue<string>("Secret")));
builder.Services.AddDbContext<WebDatabaseContext>();
builder.Services.AddScoped<IUserServise, UserServise>();

await builder.Build().RunAsync();
