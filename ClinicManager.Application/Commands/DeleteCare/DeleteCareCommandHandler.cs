using ClinicManager.Core.Repositores;
using MediatR;

namespace ClinicManager.Application.Commands.DeleteCare
{
    public class DeleteCareCommandHandler : IRequestHandler<DeleteCareCommand>
    {
        private readonly ICareRepository _careRepository;
        public DeleteCareCommandHandler(ICareRepository careRepository)
        {
            _careRepository = careRepository;
        }
        public async Task Handle(DeleteCareCommand request, CancellationToken cancellationToken)
        {
            var care = await _careRepository.GetByIdAsync(request.Id);

            care?.Remove();

            await _careRepository.SaveChangesAsync();
        }
    }
}
