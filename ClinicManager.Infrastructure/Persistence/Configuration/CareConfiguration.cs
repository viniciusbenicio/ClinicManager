using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(x => x.MedicalId).HasColumnName("MedicalId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Healthinsurance).HasColumnName("Healthinsurance").HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Start).HasColumnName("Start").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.End).HasColumnName("End").HasColumnType("datetime");
            builder.Property(x => x.TypeService).HasColumnName("TypeService").HasColumnType("int");

        }
    }
}
