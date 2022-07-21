namespace MyFirstServerSideBlazor.Authentification.Contracts
{
    public interface IAccessTokenServise
    {
        public string CreateAccessToken(string name, string role);

        public string GetName(string token);

        public string GetRole(string token);
    }
}
