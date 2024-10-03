namespace ClinicManager.Core.Entities
{
    public class User : Entity
    {
        public User(string firstName, string lastName, string username, string passwordHash, string telephone, string email, string document, string bloodtype, string height, string weight, string address, bool active, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            PasswordHash = passwordHash;
            Telephone = telephone;
            Email = email;
            Document = document;
            Bloodtype = bloodtype;
            Height = height;
            Weight = weight;
            Address = address;
            Active = active;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public string Telephone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
        public string Bloodtype { get; private set; } = string.Empty;
        public string Height { get; private set; } = string.Empty;
        public string Weight { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public bool Active { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public int RoleId { get; private set; } 
        public Role Role { get; private set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
    }

}
