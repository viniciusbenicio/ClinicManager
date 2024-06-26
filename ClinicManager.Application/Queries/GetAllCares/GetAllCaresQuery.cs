using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetAllCares
{
    public class GetAllCaresQuery : IRequest<List<CareViewModel>>
    {
    }
}
