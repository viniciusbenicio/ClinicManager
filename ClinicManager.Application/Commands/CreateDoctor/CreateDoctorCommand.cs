using MediatR;

namespace ClinicManager.Application.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<int>
    {
        public CreateDoctorCommand(string firstName, string lastName, DateTime dateOfBirth, string telephone, string email, string document, string bloodtype, string height, string weight, string address, string specialty, string cRMRegistration)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Telephone = telephone;
            Email = email;
            Document = document;
            Bloodtype = bloodtype;
            Height = height;
            Weight = weight;
            Address = address;
            Specialty = specialty;
            CRMRegistration = cRMRegistration;
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public string Telephone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
        public string Bloodtype { get; private set; } = string.Empty;
        public string Height { get; private set; } = string.Empty;
        public string Weight { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Specialty { get; private set; } = string.Empty;
        public string CRMRegistration { get; private set; } = string.Empty;
    }
}
