using System.ComponentModel.Design;

namespace ClinicManager.Core.Entities
{
    public class Doctor : Entity
    {
        public Doctor(string firstName, string lastName, DateTime dateOfBirth, string telephone, string email, string document, string bloodtype, string height, string weight, string address, string specialty, string cRMRegistration)
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
            Active = true;
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
        public bool Active { get; private set; }
        // Foreign key para associar ao usuário
        public int UserId { get; set; }
        public User User { get; set; } // Propriedade de navegação para o usuário associado
        public void Update(string firstName, string lastName, DateTime dateOfBirth, string telephone, string email, string document, string bloodtype, string height, string weight, string address, string specialty, string cRMRegistration)
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

        public void Remove()
        {
            Active = false; 
        }

    }
}
