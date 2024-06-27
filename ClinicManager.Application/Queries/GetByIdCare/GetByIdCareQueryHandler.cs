using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdCare
{
    public class GetByIdCareQueryHandler : IRequestHandler<GetByIdCareQuery, CareViewModel>
    {
        private readonly ICareRepository _careRepository;
        public GetByIdCareQueryHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }

        public async Task<CareViewModel> Handle(GetByIdCareQuery request, CancellationToken cancellationToken)
        {
            var care = await _careRepository.GetByIdAsync(request.Id);

            var careViewModels = new CareViewModel(care.PatientId, care.ServiceId, care.MedicalId, care.Healthinsurance, care.Start, care.End, care.TypeService);

            return careViewModels;
        }
    }
}
