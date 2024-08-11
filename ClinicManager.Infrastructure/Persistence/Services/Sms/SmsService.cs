using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using ClinicManager.Core.Services.Sms;

namespace ClinicManager.Infrastructure.Persistence.Services.Sms
{
    public class SmsService : ISmsService
    {

        private static readonly RegionEndpoint region = RegionEndpoint.USEast1;
        public async Task<bool> SendSMS(string message, string phoneNumber)
        {
            var snsClient = new AmazonSimpleNotificationServiceClient(ClinicManager.Core.Entities.Configuration.Sms.awsAccessKeyId, ClinicManager.Core.Entities.Configuration.Sms.awsSecretAccessKey, region);

            var sendSMSRequest = new PublishRequest
            {
                Message = message,
                PhoneNumber = phoneNumber
            };

            try
            {
                var response = await snsClient.PublishAsync(sendSMSRequest);
                Console.WriteLine("Mensagem enviada com sucesso, ID: " + response.MessageId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha ao enviar a mensagem: " + ex.Message);
                return false;
            }

            return true;
        }
    }
}
