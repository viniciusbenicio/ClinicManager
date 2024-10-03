namespace ClinicManager.Core.Entities
{
    public class Patient : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
