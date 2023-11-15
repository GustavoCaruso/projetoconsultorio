using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades;

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

            builder.Property(p => p.dataNascimento)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("dataNascimento"); // nome da coluna no BD

            builder.Property(p => p.genero)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("genero");

            builder.Property(p => p.enderecoResidencial)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasColumnName("enderecoResidencial");

            builder.Property(p => p.numeroTelefone)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasColumnName("numeroTelefone");

            builder.Property(p => p.email)
                .IsRequired()
                .HasColumnType("varchar(150)")
                .HasColumnName("email");



        }
    }
}
