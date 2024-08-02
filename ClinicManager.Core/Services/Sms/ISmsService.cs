namespace ClinicManager.Core.Services.Sms
{
    public interface ISmsService
    {
        Task<bool> SendSMS(string message, string phoneNumber);
    }
}
