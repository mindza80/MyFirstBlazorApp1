using MyFirstServerSideBlazor.Authentification.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace MyFirstServerSideBlazor.Authentification
{
    public class CryptographyServise : ICryptographyServise
    {
        private string _secret;

        public CryptographyServise(IConfiguration configuration)
        {
            _secret = configuration.GetSection("Secret").Value;
        }

        public string Hash(string message)
        {
            var encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(_secret);
            byte[] messageBytes = encoding.GetBytes(message);

            var hMacSha256Provider = new HMACSHA256(keyBytes);
            byte[] hashedMessage = hMacSha256Provider.ComputeHash(messageBytes);

            var hashedBase64 = Convert.ToBase64String(hashedMessage);
            
            return hashedBase64;
        }

        public bool VerifyHash(string hash, string message) => Hash(message) == hash;

        
    }
}
