using MediatR;

namespace ClinicManager.Application.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<int>
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get;  set; } = string.Empty;
        public decimal Price { get;  set; }
        public int Duration { get;  set; }
    }
}
