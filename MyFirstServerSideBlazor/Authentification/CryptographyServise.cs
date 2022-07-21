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

            return Convert.ToBase64String(hashedMessage);
        }

        public bool VerifyHash(string hash, string message) => Hash(message) == hash;

        private int GetDeterministicHashCode(string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}
