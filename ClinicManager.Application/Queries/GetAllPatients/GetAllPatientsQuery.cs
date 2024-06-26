using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetAllPatients
{
    public class GetAllPatientsQuery : IRequest<List<PatientViewModel>>
    {
    }
}
