using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetAllCares
{
    public class GetAllCaresQueryHandler : IRequestHandler<GetAllCaresQuery, List<CareViewModel>>
    {
        private readonly ICareRepository _careRepository;
        public GetAllCaresQueryHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }
        public async Task<List<CareViewModel>> Handle(GetAllCaresQuery request, CancellationToken cancellationToken)
        {
            var cares = await _careRepository.GetAllAsync();

            var caresViewModel = cares.Where(l => l.Active == true).Select(c => new CareViewModel(c.PatientId, c.ServiceId, c.MedicalId, c.Healthinsurance, c.Start, c.End, c.TypeService)).ToList();

            return caresViewModel;

        }
    }
}
