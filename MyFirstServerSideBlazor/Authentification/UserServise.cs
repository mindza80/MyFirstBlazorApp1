using MyFirstServerSideBlazor.Authentification.Contracts;
using MyFirstServerSideBlazor.Classes;
using MyFirstServerSideBlazor.Database;
using MyFirstServerSideBlazor.Database.Entities;
using MyFirstServerSideBlazor.DataTransferObjects_DTO;

namespace MyFirstServerSideBlazor.Authentification
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

        public async Task<Result<UserData>> CreateUser(string userName, string password)
        {
            try
            {
                var hashedPassword = _cryptographyServise.Hash(password);

                var user = new BlazorUser
                {
                    UserName = userName,
                    PasswordHash = hashedPassword,
                    Role = "Base User",
                    Created = DateTime.Now,
                    LastSeen = DateTime.Now
                };

                _webDatabaseContext.Users.Add(user);

                await _webDatabaseContext.SaveChangesAsync();

                return Result<UserData>.Success(new UserData { UserName = user.UserName, Role = user.Role });
            }
            catch (Exception ex)
            {
                return Result<UserData>.Failure(ex.Message);
            }
        }
    }
}
