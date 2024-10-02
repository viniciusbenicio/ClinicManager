using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "dbo");

            builder.HasKey(x => x.RoleId);

            builder.Property(x => x.RoleId).HasColumnName("RoleId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.RoleName).HasColumnName("RoleName").HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Users).WithOne(u => u.Role).HasForeignKey(u => u.RoleId);
        }
    }
}
