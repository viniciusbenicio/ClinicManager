using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdPatient
{
    public class GetByIdPatientQuery : IRequest<PatientViewModel>
    {

        public GetByIdPatientQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
