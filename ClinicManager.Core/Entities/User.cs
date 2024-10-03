namespace ClinicManager.Core.Entities
{
    public class User : Entity
    {
        public User(string firstName, string lastName, DateTime dateOfBirth, string bloodtype, string height, string weight, string document, string email, string telephone, string address, string username, string passwordHash, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Bloodtype = bloodtype;
            Height = height;
            Weight = weight;
            Document = document;
            Email = email;
            Telephone = telephone;
            Address = address;
            Username = username;
            PasswordHash = passwordHash;
            Active = active;
        }

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public string Bloodtype { get; private set; } = string.Empty;
        public string Height { get; private set; } = string.Empty;
        public string Weight { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;
        public string Telephone { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;

        public string Username { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;

        public bool Active { get; private set; }

        public int RoleId { get; private set; }
        public Role Role { get; private set; }
        public Doctor Doctor { get; private set; }
        public Patient Patient { get; private set; }
    }
}
