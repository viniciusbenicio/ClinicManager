using ClinicManager.Core.Entities;
using System.Net;
using System.Net.Mail;

namespace ClinicManager.Core.Services.Email
{
    public class EmailService : IEmailService
    {
        public bool Send(string toName, string toEmail, string subject, string body, string fromName = "", string fromEmail = "")
        {
            var smptClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port)
            {
                Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            var mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(toEmail, toName));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                smptClient.Send(mail);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
