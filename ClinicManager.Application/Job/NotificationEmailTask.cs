using ClinicManager.Core.Repositores;
using ClinicManager.Core.Services.Email;

namespace ClinicManager.Application.Job
{
    public class NotificationEmailTask
    {
        private readonly IJobRepository _jobRepository;
        private readonly IEmailService _emailService;
        public NotificationEmailTask(IJobRepository jobRepository, IEmailService emailService)
        {
            _jobRepository = jobRepository;
            _emailService = emailService;
        }

        public Task Execute()
        {
            var result = _jobRepository.GetConsultationNext12Hours();

            try
            {
                foreach (var item in result)
                {
                    _emailService.Send(item.NamePatient, item.EmailPatient, item.ServiceName, item.ServiceDescription, item.StartDate.ToString(), item.NameDoctor, item.EmailDoctor, "job");
                }
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
            }

            Console.WriteLine("Email communication sent successfully");

            return Task.CompletedTask;
        }
    }
}
