using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ServerSideBlazor.Authentification
{
    public class TokenAuthenticationStateProviderServise : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public TokenAuthenticationStateProviderServise(ILocalStorageService localStorage)
        {
            _localStorageService = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>("ServerSideBlazorsFirstToken");

            if (string.IsNullOrWhiteSpace(token))
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }

            bool verified = true; //Check if Token is legit

            if (verified)
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, "Your Role"), //get from token
                    new Claim(ClaimTypes.Name, "User Name") // get from token
                }, "ConnectedType"))));
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }

        public void UserAuthenticated(string userName, string role)
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, userName), //get from token
                new Claim(ClaimTypes.Name, role) // get from token
            }, "ConnectedType"))))));
        }

        public async Task UserLogOut() 
        {
            await _localStorageService.RemoveItemAsync("ServerSideBlazorsFirstToken");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }
    }
}
