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
            builder.ToTable("procedimento");
            builder.HasKey(p => p.id);

            builder.Property(p => p.nome)
                .IsRequired()
                .HasColumnType("string")
                .HasColumnName("nome");

            builder.Property(p => p.preco)
                .IsRequired()
                .HasColumnType("decimal(8,2)")
                .HasColumnName("preco");

            builder.Property(p => p.duracao)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("duracao");
        }
    }
}
