using MyFirstServerSideBlazor.DataTransferObjects_DTO;

namespace MyFirstServerSideBlazor.Authentification.Contracts
{
    public interface IAccessTokenServise
    {
        public string CreateAccessToken(UserData user);

        public string GetName(string token);

        public string GetRole(string token);

        public bool IsTokenValid(string token);
    }
}
