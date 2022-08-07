using MimeKit;
using MyFirstServerSideBlazor.Servises.Contracts;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace MyFirstServerSideBlazor.Servises
{
    public class EmailServise : IEmailServise
    {
        public async Task SendMail(string[] emails, string subject, string message)
        {
            using var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Mindaugas", "mindza@gmail.com"));
            foreach (var email in emails)
            {
                mailMessage.To.Add(new MailboxAddress(email, email));
            }
            mailMessage.Subject = subject;
            var bodyBuilder = new BodyBuilder
            {
                TextBody = message,
                HtmlBody = message
            };
            mailMessage.Body = bodyBuilder.ToMessageBody();
            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(
                userName: "apikey",
                password: "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");
            var x = await client.SendAsync(mailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
