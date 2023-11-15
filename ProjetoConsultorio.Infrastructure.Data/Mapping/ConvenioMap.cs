using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades;

namespace ProjetoConsultorio.Infrastructure.Data.Mapping
{
    public class ConvenioMap : IEntityTypeConfiguration<Convenio>
    {
        public void Configure(EntityTypeBuilder<Convenio> builder)
        {
            builder.ToTable("convenio"); // nome da tabela no SQL Server
            builder.HasKey(p => p.id); // definição de chave primária

            builder.Property(p => p.nome)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasColumnName("nome"); // nome da coluna no BD

           

           
        }
    }
}
