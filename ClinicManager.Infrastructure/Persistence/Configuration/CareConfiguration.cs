using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ClinicManager.Infrastructure.Persistence.Configuration
{
    public class CareConfiguration : IEntityTypeConfiguration<Care>
    {
        public void Configure(EntityTypeBuilder<Care> builder)
        {
            builder.ToTable("Care", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.PatientId).HasColumnName("PatientId").HasColumnType("int").IsRequired();
            builder.Property(x => x.ServiceId).HasColumnName("ServiceId").HasColumnType("int").IsRequired();
            builder.Property(x => x.DoctorId).HasColumnName("DoctorId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Healthinsurance).HasColumnName("Healthinsurance").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Start).HasColumnName("Start").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.End).HasColumnName("End").HasColumnType("datetime");
            builder.Property(x => x.TypeService).HasColumnName("TypeService").HasColumnType("int");


            // Relacionamentos
            builder.HasOne(x => x.Patient).WithOne().HasForeignKey<Care>(x => x.PatientId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Service).WithOne().HasForeignKey<Care>(x => x.ServiceId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Doctor).WithOne().HasForeignKey<Care>(x => x.DoctorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
