namespace ClinicManager.Core.Services.Email
{
    public interface IEmailService
    {
        bool Send(string toName, string toEmail, string subject, string bodyMail, string date, string fromName = "", string fromEmail = "");
    }
}
