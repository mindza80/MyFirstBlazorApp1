using Microsoft.AspNetCore.Components.Authorization;

namespace MyFirstBlazorApp.Authentification.Contracts
{
    public interface IAuthenticationStateProviderServise
    {
        public Task<AuthenticationState> GetAuthenticationStateAsync();

        public void UserAuthenticated(string userName, string role);

        public Task UserLogOut();
    }
}
