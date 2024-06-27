using ClinicManager.Application.Commands.UpdateCare;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;
        public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetByIdAsync(request.Id);

            service.Update(request.Name, request.Description, request.Price, request.Duration);

            await _serviceRepository.SaveChangesAsync();

        }
    }
}
