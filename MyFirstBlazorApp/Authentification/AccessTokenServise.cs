using MyFirstBlazorApp.Authentification.Contracts;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;

namespace MyFirstBlazorApp.Authentification
{
    public class AccessTokenServise : IAccessTokenServise
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

        public string GetName(string token) => 
            JObject.Parse(DecodeBody(token)).Value<string>("usr");

        public string GetRole(string token) =>
            JObject.Parse(DecodeBody(token)).Value<string>("rol");

        private string ToBase64(string message) => 
            Convert.ToBase64String(Encoding.UTF8.GetBytes(message));

        private string FromBase64(string base64Message) => 
            Encoding.UTF8.GetString(Convert.FromBase64String(base64Message));

        private bool IsTokenValid(string token) =>
            IsSignatureUntampered(token) && !IsTokenExpired(token);

        private bool IsSignatureUntampered(string token)
        {
            var tokenParts = token.Split('.');

            if(tokenParts.Length != 3)
            {
                return false;
            }

            return _cryptoServise.VerifyHash(tokenParts[2], $"{tokenParts[0]}.{tokenParts[1]}");
        }

        private bool IsTokenExpired(string token) => 
            DateTime.Parse(JObject.Parse(DecodeBody(token)).Value<string>("exp")) < DateTime.Now;

        private string DecodeBody(string token) => 
            FromBase64(token.Split('.')[1]);
    }
}
