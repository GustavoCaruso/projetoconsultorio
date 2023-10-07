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
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto"); //nome da table no sql server

            builder.HasKey(p => p.id); //definição de chave primária

            builder.Property(p => p.descricao).IsRequired() //campo requerido
                .HasColumnType("varchar(150)") //tipo da coluna
                .HasColumnName("descricao"); //nome da coluna no bd

            builder.Property(p => p.datavalidade).IsRequired() //campo requerido
                .HasColumnType("datetime") //tipo da coluna
                .HasColumnName("datavalidade"); //nome da coluna no bd

            builder.Property(p => p.idCategoria).IsRequired() //campo requerido
               .HasColumnType("int") //tipo da coluna
               .HasColumnName("idCategoria"); //nome da coluna no bd

            builder.Property(p => p.qtde).IsRequired() //campo requerido
               .HasColumnType("int") //tipo da coluna
               .HasColumnName("qtde"); //nome da coluna no bd

            builder.Property(p => p.valor).IsRequired() //campo requerido
               .HasColumnType("decimal(8,2)") //tipo da coluna
               .HasColumnName("valor"); //nome da coluna no bd

            builder.HasOne(p => p.categoria).WithMany(c => c.produtos)
                .HasConstraintName("fk_categoria_produtos")
                .HasForeignKey(p => p.idCategoria)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
