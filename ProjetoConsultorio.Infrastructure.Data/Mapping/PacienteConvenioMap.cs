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
    public class PacienteConvenioMap : IEntityTypeConfiguration<PacienteConvenio>
    {
        public void Configure(EntityTypeBuilder<PacienteConvenio> builder)
        {
            builder.ToTable("pacienteconvenio");
            builder.HasKey(p => p.id);

            builder.Property(p => p.convenioId).IsRequired()
               .HasColumnType("int")
               .HasColumnName("convenioId");

            builder.Property(p => p.pacienteId).IsRequired()
              .HasColumnType("int")
              .HasColumnName("pacienteId");


            //relacionamento
            builder.HasOne(p => p.convenio).WithMany(c => c.pacienteconvenio)
                .HasConstraintName("fk_paciente_convenio_convenio")
                .HasForeignKey(p => p.convenioId)
                .OnDelete(DeleteBehavior.NoAction);




            //relacionamento
            builder.HasOne(p => p.paciente).WithMany(c => c.pacienteconvenio)
                .HasConstraintName("fk_paciente_convenio_paciente")
                .HasForeignKey(p => p.pacienteId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
