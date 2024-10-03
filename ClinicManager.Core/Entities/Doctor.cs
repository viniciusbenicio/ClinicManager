namespace ClinicManager.Core.Entities
{
    public class Doctor : Entity
    {
        public Doctor(string specialty, string cRMRegistration)
        {
            Specialty = specialty;
            CRMRegistration = cRMRegistration;
        }

        public string Specialty { get; private set; }
        public string CRMRegistration { get; private set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public void Update(string specialty, string cRMRegistration)
        {
            Specialty = specialty;
            CRMRegistration = cRMRegistration;
        }
    }
}
