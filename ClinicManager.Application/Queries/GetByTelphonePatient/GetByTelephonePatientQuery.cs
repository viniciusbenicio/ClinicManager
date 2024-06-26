using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetByTelphonePatient
{
    public class GetByTelephonePatientQuery : IRequest<PatientViewModel>
    {
        public GetByTelephonePatientQuery(string number)
        {
            Number = number;
        }
        public string Number { get; set; }

    }
}
