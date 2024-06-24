namespace ClinicManager.Core.Entities
{
    public class Patient : Entity
    {
        public Patient(string firstName, string lastName, DateTime dateOfBirth, string telephone, string email, string document, string bloodtype, string height, string weight, string address)
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
    }
}
