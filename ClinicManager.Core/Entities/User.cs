using System.Data;

namespace ClinicManager.Core.Entities
{
    public class User : Entity
    {
        public User(string username, string passwordHash, int roleId)
        {
            Username = username;
            PasswordHash = passwordHash;
            RoleId = roleId;
        }

        public int UserId { get; set; } // Chave primária
        public string Username { get; set; } // Nome de usuário para login

        public string PasswordHash { get; set; } // Senha criptografada
        public int RoleId { get; set; } // Chave estrangeira para associar ao perfil
        // Propriedade de navegação para a Role (perfil do usuário)
        public Role Role { get; set; }
        // Se houver um relacionamento entre User e Doctor (um médico é um usuário), podemos incluir a propriedade de navegação
        public Doctor Doctor { get; set; } // Relação 1-1 com a entidade Doctor
    }

}
