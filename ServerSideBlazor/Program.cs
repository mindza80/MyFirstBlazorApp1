using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using ServerSideBlazor.Authentification;
using ServerSideBlazor.Authentification.Contracts;
using ServerSideBlazor.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProviderServise>();
builder.Services.AddSingleton<ICryptographyServise, CryptographyServise>(x => new CryptographyServise(builder.Configuration.GetValue<string>("Secret")));
builder.Services.AddDbContext<WebDatabaseContext>();
builder.Services.AddScoped<IUserServise, UserServise>();
builder.Services.AddScoped<IAccessTokenServise, AccessTokenServise>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
