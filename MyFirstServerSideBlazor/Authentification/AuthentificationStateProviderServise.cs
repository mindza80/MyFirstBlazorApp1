using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyFirstServerSideBlazor.Authentification.Contracts;
using MyFirstServerSideBlazor.DataTransferObjects_DTO;
using System.Security.Claims;

namespace MyFirstServerSideBlazor.Authentification
{
    public class TokenAuthenticationStateProviderServise : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IAccessTokenServise _accessTokenServise;

        public TokenAuthenticationStateProviderServise(
            ILocalStorageService localStorage,
            IAccessTokenServise accessTokenServise)
        {
            _localStorageService = localStorage;
            _accessTokenServise = accessTokenServise;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>("MyFirstServerSideBlazorsFirstToken");

            if (string.IsNullOrWhiteSpace(token))
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }

            bool verified = _accessTokenServise.IsTokenValid(token);

            if (verified)
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, _accessTokenServise.GetRole(token)),
                    new Claim(ClaimTypes.Name, _accessTokenServise.GetName(token)) 
                }, "ConnectedType"))));
            }

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }

        public void UserAuthenticated(UserData user)
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, user.Role), 
                new Claim(ClaimTypes.Name, user.UserName) 
            }, "ConnectedType"))))));
        }

        public async Task UserLogOut() 
        {
            await _localStorageService.RemoveItemAsync("MyFirstServerSideBlazorsFirstToken");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }
    }
}
