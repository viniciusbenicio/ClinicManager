using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdCare
{
    public class GetByIdCareQuery : IRequest<CareViewModel>
    {

        public GetByIdCareQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
