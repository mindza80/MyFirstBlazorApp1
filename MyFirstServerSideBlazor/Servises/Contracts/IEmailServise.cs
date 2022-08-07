namespace MyFirstServerSideBlazor.Servises.Contracts
{
    public interface IEmailServise
    {
        public Task SendMail(string[] emails, string subject, string message);
    }
}
