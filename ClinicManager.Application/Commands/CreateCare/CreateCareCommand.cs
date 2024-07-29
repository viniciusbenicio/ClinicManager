using ClinicManager.Core.Enums;
using MediatR;

namespace ClinicManager.Application.Commands.CreateCare
{
    public class CreateCareCommand : IRequest<int>
    {
        public int PatientId { get;  set; }
        public int ServiceId { get;  set; }
        public int MedicalId { get;  set; }
        public string Healthinsurance { get;  set; } = string.Empty;
        public DateTime Start { get;  set; }
        public TypeServiceENUM TypeService { get;  set; }
    }
}
