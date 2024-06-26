using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.UpdateCare
{
    public class UpdateCareCommandHandler : IRequestHandler<UpdateCareCommand>
    {
        private readonly ICareRepository _careRepository;
        public UpdateCareCommandHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }
        public async Task Handle(UpdateCareCommand request, CancellationToken cancellationToken)
        {
            var care = await _careRepository.GetByIdAsync(request.Id);

            care.Update(request.PatientId, request.ServiceId, request.MedicalId, request.Healthinsurance, request.Start, request.End, request.TypeService);

            await _careRepository.SaveChangesAsync();

        }
    }
}
