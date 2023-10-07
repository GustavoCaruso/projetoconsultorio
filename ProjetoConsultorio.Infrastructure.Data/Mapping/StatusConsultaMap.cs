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
    public class StatusConsultaMap : IEntityTypeConfiguration<StatusConsulta>
    {
        public void Configure(EntityTypeBuilder<StatusConsulta> builder)
        {
            builder.ToTable("statusconsulta");

            builder.HasKey(p => p.id); 

            builder.Property(p => p.nome).IsRequired() 
                .HasColumnType("varchar(150)")
                .HasColumnName("nome"); 
        }

    }
}
