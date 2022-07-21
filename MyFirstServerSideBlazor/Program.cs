using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyFirstServerSideBlazor.Authentification;
using MyFirstServerSideBlazor.Authentification.Contracts;
using MyFirstServerSideBlazor.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();

var secret = builder.Configuration.GetValue<string>("Secret");

builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProviderServise>();
builder.Services.AddScoped<ICryptographyServise, CryptographyServise>();
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