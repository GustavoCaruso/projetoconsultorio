using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades; // Certifique-se de usar o namespace correto

namespace ProjetoConsultorio.Infrastructure.Data.Mapping
{
    public class MedicoDisponibilidadeMap : IEntityTypeConfiguration<MedicoDisponibilidade>
    {
        public void Configure(EntityTypeBuilder<MedicoDisponibilidade> builder)
        {
            builder.ToTable("medicodisponibilidade"); // Nome da tabela no SQL Server
            builder.HasKey(p => p.id); // Definição da chave primária

        }
    }
}
