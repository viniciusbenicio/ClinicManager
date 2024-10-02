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

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Username).HasColumnName("Username").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").HasColumnType("varchar").HasMaxLength(255).IsRequired();

            builder.HasOne(x => x.Role).WithMany(r => r.Users).HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Doctor).WithOne(d => d.User).HasForeignKey<Doctor>(d => d.UserId);
        }


    }
}
