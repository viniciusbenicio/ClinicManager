using MediatR;

namespace ClinicManager.Application.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest
    {
        public UpdateDoctorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Bloodtype { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Address { get; set; }
        public string Specialty { get; set; }
        public string CRMRegistration { get; set; }
    }
}
