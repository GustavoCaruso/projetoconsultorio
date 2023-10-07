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
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria"); //nome da table no sql server
            builder.HasKey(p => p.id); //definição de chave primária
            builder.Property(p => p.descricao).IsRequired() //campo requerido
                .HasColumnType("varchar(150)") //tipo da coluna
                .HasColumnName("descricao"); //nome da coluna no bd

        }
    }
}
