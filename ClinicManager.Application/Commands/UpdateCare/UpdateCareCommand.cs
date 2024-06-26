using MediatR;

namespace ClinicManager.Application.Commands.UpdateCare
{
    public class UpdateCareCommand : IRequest
    {
        public UpdateCareCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ServiceId { get; set; }
        public int MedicalId { get; set; }
        public string Healthinsurance { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TypeService { get; set; }
    }
}
