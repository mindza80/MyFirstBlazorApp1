using MyFirstBlazorApp.Authentification.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace MyFirstBlazorApp.Authentification
{
    public class CryptographyServise : ICryptographyServise
    {
        private readonly string _secret;

        public CryptographyServise(string secret)
        {
            _secret = secret;
        }

        public string Hash(string message)
        {
            var encoding = new ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(_secret);
            byte[] messageBytes = encoding.GetBytes(message);

            var hMacSha256Provider = new HMACSHA256(keyBytes);
            byte[] hashedMessage = hMacSha256Provider.ComputeHash(messageBytes);

            return Convert.ToBase64String(hashedMessage);
        } 

        public bool VerifyHash(string hash, string message) => Hash(message) == hash;
    }
}
