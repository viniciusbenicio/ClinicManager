using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdDoctor
{
    public class GetByIdDoctorQuery : IRequest<DoctorViewModel>
    {

        public GetByIdDoctorQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
