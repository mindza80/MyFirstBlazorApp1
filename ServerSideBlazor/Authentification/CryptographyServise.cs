using ServerSideBlazor.Authentification.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace ServerSideBlazor.Authentification
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
            var hashed = GetDeterministicHashCode(message).ToString();

            return hashed;
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
