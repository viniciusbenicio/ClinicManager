using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using ClinicManager.Core.Services.Sms;
using static ClinicManager.Core.Entities.Configuration;

namespace ClinicManager.Infrastructure.Persistence.Services.Sms
{
    public class SmsService : ISmsService
    {
        //private static readonly string awsAccessKeyId = "";
        //private static readonly string awsSecretAccessKey = "";

        private static readonly RegionEndpoint region = RegionEndpoint.USEast1;
        public async Task<bool> SendSMS(string message, string phoneNumber)
        {
            var sms = new SmsConfiguracao();
            var snsClient = new AmazonSimpleNotificationServiceClient(sms.awsAccessKeyId, sms.awsSecretAccessKey, region);

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
