using Microsoft.EntityFrameworkCore;
using ProjetoConsultorio.Domain.entidades;
using ProjetoConsultorio.Infrastructure.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Infrastructure.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Medico> medico { get; set; }
        public DbSet<Paciente> paciente { get; set; }
        public DbSet<Disponibilidade> disponibilidade { get; set; }

        public DbSet<Convenio> convenio { get; set; }
        public DbSet<MedicoConvenio> medicoconvenio { get; set; }
        public DbSet<ConsultaMedicoPaciente> consultamedicopaciente { get; set; }
        public DbSet<MedicoDisponibilidade> medicodisponibilidade { get; set; }
        public DbSet<StatusConsulta> statusconsulta { get; set; }

        public DbSet<Usuario> usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConexao = @"Server=GUSTAVO-CARUSO;DataBase=Projeto29;integrated security=true;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(stringConexao);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            modelBuilder.Entity<Categoria>(new CategoriaMap().Configure);
            modelBuilder.Entity<Paciente>(new PacienteMap().Configure);

            modelBuilder.Entity<Medico>(new MedicoMap().Configure);
            modelBuilder.Entity<Disponibilidade>(new DisponibilidadeMap().Configure);
            modelBuilder.Entity<Convenio>(new ConvenioMap().Configure);
            modelBuilder.Entity<MedicoConvenio>(new MedicoConvenioMap().Configure);
            modelBuilder.Entity<ConsultaMedicoPaciente>(new ConsultaMedicoPacienteMap().Configure);
            modelBuilder.Entity<MedicoDisponibilidade>(new MedicoDisponibilidadeMap().Configure);
            modelBuilder.Entity<StatusConsulta>(new StatusConsultaMap().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);


        }
    }
}
