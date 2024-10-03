using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Specialty).HasColumnName("Specialty").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CRMRegistration).HasColumnName("CRMRegistration").HasColumnType("varchar").HasMaxLength(100).IsRequired();


            builder.HasOne(x => x.User).WithOne(u => u.Doctor).HasForeignKey<Doctor>(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
