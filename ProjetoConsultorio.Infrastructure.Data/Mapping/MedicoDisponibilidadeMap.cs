using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades; // Certifique-se de usar o namespace correto

namespace ProjetoConsultorio.Infrastructure.Data.Mapping
{
    public class MedicoDisponibilidadeMap : IEntityTypeConfiguration<MedicoDisponibilidade>
    {
        public void Configure(EntityTypeBuilder<MedicoDisponibilidade> builder)
        {
            builder.ToTable("medicodisponibilidade");
            builder.HasKey(p => p.id);

            builder.Property(p => p.disponibilidadeId).IsRequired()
               .HasColumnType("int")
               .HasColumnName("disponibilidadeId");

            builder.Property(p => p.medicoId).IsRequired()
              .HasColumnType("int")
              .HasColumnName("medicoId");


            //relacionamento
            builder.HasOne(p => p.disponibilidade).WithMany(c => c.medicodisponibilidade)
                .HasConstraintName("fk_medico_disponibilidade_disponibilidade")
                .HasForeignKey(p => p.disponibilidadeId)
                .OnDelete(DeleteBehavior.NoAction);




            //relacionamento
            builder.HasOne(p => p.medico).WithMany(c => c.medicodisponibilidade)
                .HasConstraintName("fk_medico_disponibilidade_medico")
                .HasForeignKey(p => p.medicoId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
