using MediatR;

namespace ClinicManager.Application.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Bloodtype { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
