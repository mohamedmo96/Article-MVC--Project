using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
using System.Net.Mail;

namespace Article.Code
{
    public class EmailSender : IEmailSender
    {
        public Task  SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("mohamedhakk67@gmail.com" , "ozohdtawbiyczhkm\r\n"),
                EnableSsl  =true,
            };
           return smtpClient.SendMailAsync("mohamedhakk67@gmail.com", email,subject,htmlMessage);
        }
    }
}
