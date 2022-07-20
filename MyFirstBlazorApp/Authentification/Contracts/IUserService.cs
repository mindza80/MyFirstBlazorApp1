using MyFirstBlazorApp.DataTransferObjects_DTO;

namespace MyFirstBlazorApp.Authentification.Contracts
{
    public interface IUserServise
    {
        public UserData VerifyLogin(string userName, string password);
    }
}
