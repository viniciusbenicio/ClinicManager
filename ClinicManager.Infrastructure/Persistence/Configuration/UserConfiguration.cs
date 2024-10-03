using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Telephone).HasColumnName("Telephone").HasColumnType("varchar").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Document).HasColumnName("Document").HasColumnType("varchar").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Bloodtype).HasColumnName("Bloodtype").HasColumnType("varchar").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Height).HasColumnName("Height").HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Weight).HasColumnName("Weight").HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Address).HasColumnName("Address").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Username).HasColumnName("Username").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").HasColumnType("varchar").HasMaxLength(255).IsRequired();

            builder.HasOne(x => x.Role).WithMany(r => r.Users).HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.Doctor).WithOne(d => d.User).HasForeignKey<Doctor>(d => d.UserId);
            builder.HasOne(x => x.Patient).WithOne(p => p.User).HasForeignKey<Patient>(p => p.UserId);
        }
    }
}
