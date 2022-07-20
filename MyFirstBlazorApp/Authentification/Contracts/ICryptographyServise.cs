namespace MyFirstBlazorApp.Authentification.Contracts
{
    public interface ICryptographyServise
    {
        public string Hash(string message);

        public bool VerifyHash(string hash, string message);
    }
}
