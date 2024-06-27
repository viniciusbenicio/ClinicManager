using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdService
{
    public class GetByIdServiceQuery : IRequest<ServiceViewModel>
    {

        public GetByIdServiceQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
