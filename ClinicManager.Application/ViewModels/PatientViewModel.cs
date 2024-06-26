namespace ClinicManager.Application.ViewModels
{
    public class PatientViewModel
    {
        public PatientViewModel(string firstName, string lastName, DateTime dateOfBirth, string telephone, string email, string document, string bloodtype, string height, string weight, string address)
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
        }

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
    }
}
