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
            builder.Property(x => x.Specialty).HasColumnName("Specialty").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CRMRegistration).HasColumnName("CRMRegistration").HasColumnType("varchar").HasMaxLength(100).IsRequired();
        }
    }
}
