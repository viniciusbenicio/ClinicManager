using MediatR;

namespace ClinicManager.Application.Commands.UpdateCare
{
    public class UpdateServiceCommand : IRequest
    {
        public UpdateServiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get;  set; } = string.Empty;
        public string Description { get;  set; } = string.Empty;
        public decimal Price { get;  set; }
        public int Duration { get;  set; }
    }
}
