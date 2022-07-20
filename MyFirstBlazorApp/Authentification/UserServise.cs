using MyFirstBlazorApp.Authentification.Contracts;
using MyFirstBlazorApp.Database;
using MyFirstBlazorApp.DataTransferObjects_DTO;

namespace MyFirstBlazorApp.Authentification
{
    public class UserServise : IUserServise
    {
        private readonly ICryptographyServise _cryptographyServise;
        private readonly WebDatabaseContext _webDatabaseContext;

        public UserServise(
            ICryptographyServise cryptographyServise, 
            WebDatabaseContext webDatabaseContext)
        {
            _cryptographyServise = cryptographyServise;
            _webDatabaseContext = webDatabaseContext;
        }        

        public UserData VerifyLogin(string userName, string password)
        {
            var hashedPassword = _cryptographyServise.Hash(password);
            var user = _webDatabaseContext.Users.Where(x => x.UserName == userName && x.PasswordHash == hashedPassword).FirstOrDefault();

            return user == null
                ? null
                : new UserData
                {
                    UserName = user.UserName,
                    Role = user.Role
                };
        }
    }
}
