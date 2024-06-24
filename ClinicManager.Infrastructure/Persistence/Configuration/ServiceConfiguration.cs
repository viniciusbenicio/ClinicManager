using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Price).HasColumnName("Price").HasColumnType("decimal").HasPrecision(19, 4);
            builder.Property(x => x.Duration).HasColumnName("Duration").HasColumnType("int");
        }
    }
}
