using Amazon.SimpleNotificationService.Model;
using Amazon.SimpleNotificationService;
using Amazon;
using ClinicManager.Core.Services.Sms;

namespace ClinicManager.Infrastructure.Persistence.Services.Sms
{
    public class SmsService : ISmsService
    {
        private static readonly string awsAccessKeyId = "KEY";
        private static readonly string awsSecretAccessKey = "SECRETKEY";


       
        private static readonly RegionEndpoint region = RegionEndpoint.USEast1;
        public async Task<bool> SendSMS(string message, string phoneNumber)
        {
            var snsClient = new AmazonSimpleNotificationServiceClient(awsAccessKeyId, awsSecretAccessKey, region);

            var sendSMSRequest = new PublishRequest
            {
                Message = "Sua mensagem de teste SMS",
                PhoneNumber = "+5511952355735"
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
