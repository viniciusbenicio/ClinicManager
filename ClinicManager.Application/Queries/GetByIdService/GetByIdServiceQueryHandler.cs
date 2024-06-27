using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Queries.GetByIdService
{
    public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQuery, ServiceViewModel>
    {
        private readonly IServiceRepository _serviceRepository;
        public GetByIdServiceQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceViewModel> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            var serviceViewModels = new ServiceViewModel(service.Name, service.Description, service.Price, service.Duration);

            return serviceViewModels;
        }
    }
}
