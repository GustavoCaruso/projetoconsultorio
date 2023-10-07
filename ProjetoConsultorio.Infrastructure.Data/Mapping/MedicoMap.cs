using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades; // Certifique-se de usar o namespace correto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Infrastructure.Data.Mapping
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("medico"); // nome da tabela no SQL Server

            builder.HasKey(p => p.id); // definição da chave primária

            builder.Property(p => p.nome)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasColumnName("nome"); // nome da coluna no BD

            builder.Property(p => p.crm)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasColumnName("crm"); // nome da coluna no BD

            builder.Property(p => p.especializacao)
               .IsRequired()
               .HasColumnType("varchar(150)")
               .HasColumnName("especializacao"); // nome da coluna no BD

            // Configurar relacionamento muitos-para-muitos com Convênio
            builder
                .HasMany(m => m.medicoconvenio)
                .WithOne(mc => mc.medico)
                .HasForeignKey(mc => mc.medicoId);

            // Configurar relacionamento um-para-muitos com ConsultaMedicoPaciente
            builder
                .HasMany(m => m.consultamedicopaciente)
                .WithOne(cmp => cmp.Medico)
                .HasForeignKey(cmp => cmp.medicoId);

        }
    }
}
