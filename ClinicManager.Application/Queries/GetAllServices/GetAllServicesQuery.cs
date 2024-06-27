using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetAllServices
{
    public class GetAllServicesQuery : IRequest<List<ServiceViewModel>>
    {
    }
}
