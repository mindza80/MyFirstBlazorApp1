using MyFirstServerSideBlazor.DataTransferObjects_DTO;

namespace MyFirstServerSideBlazor.Authentification.Contracts
{
    public interface IUserServise
    {
        public UserData VerifyLogin(string userName, string password);
    }
}
