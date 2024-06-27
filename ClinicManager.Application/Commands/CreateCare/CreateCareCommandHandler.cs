using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.CreateCare
{
    public class CreateCareCommandHandler : IRequestHandler<CreateCareCommand, int>
    {
        private readonly ICareRepository _careRepository;
        public CreateCareCommandHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }
        public async Task<int> Handle(CreateCareCommand request, CancellationToken cancellationToken)
        {
            var care = new Care(request.PatientId, request.ServiceId, request.MedicalId, request.Healthinsurance, request.Start, request.End.Value, request.TypeService);

            await _careRepository.AddAsync(care);
            await _careRepository.SaveChangesAsync();

            return care.Id;
        }
    }
}
