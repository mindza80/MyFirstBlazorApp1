using System.Text;
using System.Text.Json;

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

        public string CreateAccessToken(string name, string role)
        {
            var header = ToBase64(JsonSerializer.Serialize(new
            {
                alg = "HS256",
                typ = "JWT"
            }));

            var body = ToBase64(JsonSerializer.Serialize(new
            {
                iss = "MyFirstTokenServise",
                exp = DateTime.Now.AddHours(TokenIsValidFor).ToString("yyyy-MM-dd HH:mm:ss"),
                usr = name,
                rol = role
            }));

            var signature = _cryptoServise.Hash($"{header}.{body}");

            return $"{header}.{body}.{signature}";
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

        private string ToBase64(string message) => Convert.ToBase64String(Encoding.UTF8.GetBytes(message));

        private string FromBase64(string base64Message) => Encoding.UTF8.GetString(Convert.FromBase64String(base64Message));

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
