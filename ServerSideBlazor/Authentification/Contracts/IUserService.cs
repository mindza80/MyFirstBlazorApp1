using ServerSideBlazor.DataTransferObjects_DTO;

namespace ServerSideBlazor.Authentification.Contracts
{
    public interface IUserServise
    {
        public UserData VerifyLogin(string userName, string password);
    }
}
