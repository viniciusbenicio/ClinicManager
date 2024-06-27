using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        private readonly IServiceRepository _serviceRepository;
        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service(request.Name, request.Description, request.Price, request.Duration);

            await _serviceRepository.AddAsync(service);
            await _serviceRepository.SaveChangesAsync();

            return service.Id;
        }
    }
}
