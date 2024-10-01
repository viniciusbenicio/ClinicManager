using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            // Chave primária
            builder.HasKey(x => x.UserId);

            // Propriedades da tabela Users
            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Username).HasColumnName("Username").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").HasColumnType("varchar").HasMaxLength(255).IsRequired();

            // Relacionamento com Role (perfil)
            builder.HasOne(x => x.Role).WithMany(r => r.Users).HasForeignKey(x => x.RoleId);

            // Relacionamento 1-1 com Doctor
            builder.HasOne(x => x.Doctor).WithOne(d => d.User).HasForeignKey<Doctor>(d => d.UserId);
        }


    }
}
