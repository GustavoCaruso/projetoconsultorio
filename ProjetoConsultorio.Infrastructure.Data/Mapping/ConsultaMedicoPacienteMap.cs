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
    public class ConsultaMedicoPacienteMap : IEntityTypeConfiguration<ConsultaMedicoPaciente>
    {
        public void Configure(EntityTypeBuilder<ConsultaMedicoPaciente> builder)
        {
            builder.ToTable("consultamedicopaciente");
            builder.HasKey(p => p.id);

            builder.Property(p => p.DataHora)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("dataHora");

           

          

            
        }
    }
}
