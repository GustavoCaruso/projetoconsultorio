using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoConsultorio.Domain.entidades;

using System;

namespace ProjetoConsultorio.Infrastructure.Data.Mapping
{
    public class DisponibilidadeMap : IEntityTypeConfiguration<Disponibilidade>
    {
        public void Configure(EntityTypeBuilder<Disponibilidade> builder)
        {
            builder.ToTable("disponibilidade");
            builder.HasKey(p => p.id);

            builder.Property(p => p.diaDaSemana).IsRequired()
                .HasColumnType("int")
                .HasColumnName("diaDaSemana");

            builder.Property(p => p.horaInicio).IsRequired()
                .HasColumnType("time")
                .HasColumnName("horaInicio");

            builder.Property(p => p.horaFim).IsRequired()
                .HasColumnType("time")
                .HasColumnName("horaFim");

        }
    }
}
