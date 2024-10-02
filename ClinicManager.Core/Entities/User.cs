namespace ClinicManager.Core.Entities
{
    public class User
    {
        public User(string username, string passwordHash, int roleId)
        {
            Username = username;
            PasswordHash = passwordHash;
            RoleId = roleId;
        }

        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Doctor Doctor { get; set; }
    }

}
