using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetAllDoctors
{
    public class GetAllDoctorsQuery : IRequest<List<DoctorViewModel>>
    {
    }
}
