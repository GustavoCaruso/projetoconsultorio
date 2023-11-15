using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades;

namespace ProjetoConsultorio.Infrastructure.Data.Mapping
{
    public class MedicoConvenioMap : IEntityTypeConfiguration<MedicoConvenio>
    {
        public void Configure(EntityTypeBuilder<MedicoConvenio> builder)
        {
            builder.ToTable("medicoconvenio");
            builder.HasKey(p => p.id);

            builder.Property(p => p.convenioId).IsRequired()
               .HasColumnType("int")
               .HasColumnName("convenioId");

            builder.Property(p => p.medicoId).IsRequired()
              .HasColumnType("int")
              .HasColumnName("medicoId");

            //relacionamento
            builder.HasOne(p => p.convenio).WithMany(c => c.medicoconvenio)
                .HasConstraintName("fk_medico_convenio_convenio")
                .HasForeignKey(p => p.convenioId)
                .OnDelete(DeleteBehavior.NoAction);

            //relacionamento
            builder.HasOne(p => p.medico).WithMany(c => c.medicoconvenio)
                .HasConstraintName("fk_medico_convenio_medico")
                .HasForeignKey(p => p.medicoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
