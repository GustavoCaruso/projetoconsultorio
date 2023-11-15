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
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("paciente"); 

            builder.HasKey(p => p.id); 

            builder.Property(p => p.nome).IsRequired() 
                .HasColumnType("varchar(150)") 
                .HasColumnName("nome"); 

            builder.Property(p => p.rg).IsRequired() 
                .HasColumnType("varchar(150)") 
                .HasColumnName("rg"); 

            builder.Property(p => p.cpf).IsRequired() 
                .HasColumnType("varchar(150)") 
                .HasColumnName("cpf"); 

            builder.Property(p => p.genero).IsRequired() 
                .HasColumnType("varchar(150)") 
                .HasColumnName("genero"); 

            builder.Property(p => p.estadoCivil).IsRequired() 
                .HasColumnType("varchar(150)") 
                .HasColumnName("estadoCivil"); 

            builder.Property(p => p.telefone).IsRequired() 
                .HasColumnType("varchar(150)") 
                .HasColumnName("telefone"); 

            builder.Property(p => p.email).IsRequired() 
                .HasColumnType("varchar(150)") 
                .HasColumnName("email");
        }
    }
}
