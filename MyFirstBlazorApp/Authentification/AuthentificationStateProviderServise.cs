using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace MyFirstBlazorApp.Authentification
{
    public class AuthenticationStateProviderServise : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public AuthenticationStateProviderServise(ILocalStorageService localStorage)
        {
            _localStorageService = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = _localStorageService.GetItemAsync<string>("MyFirstToken");


        }
    }
}
