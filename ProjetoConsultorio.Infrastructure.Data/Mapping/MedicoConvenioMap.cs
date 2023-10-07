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
    public class MedicoConvenioMap : IEntityTypeConfiguration<MedicoConvenio>
    {
        public void Configure(EntityTypeBuilder<MedicoConvenio> builder)
        {
            builder.ToTable("medicoconvenio"); //nome da table no sql server
            //builder.HasKey(p => p.id); //definição de chave primária
            

            // Configure as chaves primárias
            builder.HasKey(mc => new { mc.medicoId, mc.convenioId });

            // Configure as relações entre Médico e Convênio
            builder
                .HasOne(mc => mc.medico)
                .WithMany(m => m.medicoconvenio)
                .HasForeignKey(mc => mc.medicoId);

            builder
                .HasOne(mc => mc.convenio)
                .WithMany(c => c.medicoconvenio)
                .HasForeignKey(mc => mc.convenioId);
        }

    }
    
}
