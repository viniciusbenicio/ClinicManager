namespace ClinicManager.Application.ViewModels
{
    public class DoctorViewModel
    {
        public DoctorViewModel(string firstname, string lastName, DateTime dateOfBirth, string telephone, string email, string document, string bloodtype, string height, string weight, string address, string specialty, string cRMRegistration)
        {
            FirstName = firstname;
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

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Telephone { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }
        public string Bloodtype { get; private set; }
        public string Height { get; private set; }
        public string Weight { get; private set; }
        public string Address { get; private set; }
        public string Specialty { get; private set; }
        public string CRMRegistration { get; private set; }
    }
}
