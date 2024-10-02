namespace ClinicManager.Core.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = [];    
    }
}
