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
    class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("consulta");
            builder.HasKey(p => p.id);

            builder.Property(p => p.data).IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("data");

            builder.Property(p => p.horaInicio).IsRequired()
                .HasColumnType("time")
                .HasColumnName("horaInicio");

            builder.Property(p => p.horaFim).IsRequired()
                .HasColumnType("time")
                .HasColumnName("horaFim");

            builder.HasOne(p => p.procedimento).WithMany(c => c.consulta)
                .HasConstraintName("fk_procedimento_consulta")
                .HasForeignKey(p => p.procedimentoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.paciente).WithMany(c => c.consulta)
               .HasConstraintName("fk_paciente_consulta")
               .HasForeignKey(p => p.pacienteId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.convenio).WithMany(c => c.consulta)
              .HasConstraintName("fk_convenio_consulta")
              .HasForeignKey(p => p.convenioId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.statusconsulta).WithMany(c => c.consulta)
              .HasConstraintName("fk_statusconsulta_consulta")
              .HasForeignKey(p => p.statusConsultaId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.medico).WithMany(c => c.consulta)
             .HasConstraintName("fk_medico_consulta")
             .HasForeignKey(p => p.medicoId)
             .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
