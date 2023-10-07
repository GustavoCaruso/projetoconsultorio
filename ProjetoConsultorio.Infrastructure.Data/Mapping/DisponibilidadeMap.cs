using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Infrastructure.Data.Mapping
{
    public class DisponibilidadeMap : IEntityTypeConfiguration<Disponibilidade>
    {
         public void Configure(EntityTypeBuilder<Disponibilidade> builder)
        {
            builder.ToTable("disponibilidade");
            builder.HasKey(d => d.id);

          
            builder.Property(d => d.diaDaSemana).HasColumnName("diaDaSemana");
            builder.Property(d => d.horaInicio).HasColumnName("horaInicio");
            builder.Property(d => d.horaFim).HasColumnName("horaFim");

            //relacionamento com médico
            builder.HasOne(p => p.medico).WithMany(c => c.disponibilidade)
                .HasConstraintName("fk_medico_disponibilidade")
                .HasForeignKey(p => p.medicoId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    

    
    }
}
