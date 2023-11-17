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
    public class ProcedimentoMap : IEntityTypeConfiguration<Procedimento>
    {
        public void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            builder.ToTable("procedimento"); // nome da tabela no SQL Server
            builder.HasKey(p => p.id); // definição de chave primária

            builder.Property(p => p.nome).IsRequired() // campo requerido
                .HasColumnType("varchar(150)") // tipo da coluna
                .HasColumnName("nome"); // nome da coluna no banco de dados

            builder.Property(p => p.preco) // campo requerido
               .HasColumnType("decimal(8,2)") // tipo da coluna
               .HasColumnName("preco"); // nome da coluna no banco de dados

            builder.Property(p => p.duracao).IsRequired() // campo requerido
               .HasColumnType("int") // tipo da coluna
               .HasColumnName("duracao"); // nome da coluna no banco de dados
        }
    }
}
