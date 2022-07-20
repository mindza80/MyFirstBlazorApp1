namespace MyFirstBlazorApp.Authentification
{
    public class AccessTokenServise
    {
        private const int TokenIsValidFor = 8;

        private readonly CryptographyServise _cryptoServise;

        public AccessTokenServise(CryptographyServise cryptoServise)
        {
            _cryptoServise = cryptoServise;
        }

        public string CreateAccessToken(string name)
        {

        }

        public string GetName(string token)
        {

        }

        public string GetRole(string token)
        {

        }

        private string DecodeBody(string token)
        {

        }

        private string ToBase64()
        {

        }

        private string FromBase64()
        {

        }

        private bool IsTokenValid(string token)
        {

        }

        private bool IsSignatureUntampered(string token)
        {

        }

        private bool IsTokenExpired(string token)
        {

        }
    }
}
