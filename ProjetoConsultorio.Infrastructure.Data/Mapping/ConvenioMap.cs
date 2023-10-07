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
    public class ConvenioMap: IEntityTypeConfiguration<Convenio>
    {
        public void Configure(EntityTypeBuilder<Convenio> builder)
        {
            builder.ToTable("convenio"); //nome da table no sql server
            builder.HasKey(p => p.id); //definição de chave primária

            builder.Property(p => p.nome).IsRequired() //campo requerido
                .HasColumnType("varchar(150)") //tipo da coluna
                .HasColumnName("nome"); //nome da coluna no bd


            // Configurar relacionamento muitos-para-muitos com Médico
            builder
                .HasMany(c => c.medicoconvenio)
                .WithOne(mc => mc.convenio)
                .HasForeignKey(mc => mc.convenioId);
        }
    }
}
