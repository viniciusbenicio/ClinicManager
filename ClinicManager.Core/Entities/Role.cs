namespace ClinicManager.Core.Entities
{
    public class Role : Entity
    {
        public int RoleId { get; set; } // Chave primária
        public string RoleName { get; set; } // Nome do perfil (e.g., Médico, Administrador, Recepcionista)
        // Lista de usuários que possuem esse perfil
        public ICollection<User> Users { get; set; }
    }
}
