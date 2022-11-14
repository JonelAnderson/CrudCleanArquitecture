using ARQUICAPAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ARQUICAPAS.Infrastructure.Persistences.Contexts.Configurations
{
    public class EncargadoConfiguration : IEntityTypeConfiguration<Encargado>
    {
        public void Configure(EntityTypeBuilder<Encargado> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("EncargadoId");
            builder.Property(e => e.Email).HasMaxLength(150);

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.Property(e => e.Phone).HasMaxLength(11);
        }
    }
}
