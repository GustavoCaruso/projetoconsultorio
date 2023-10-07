using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ProjetoConsultorio.Application.Models;
using ProjetoConsultorio.Domain.entidades;
using ProjetoConsultorio.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoConsultorio.Domain.interfaces;
using ProjetoConsultorio.Service.services;
using ProjetoConsultorio.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProjetoConsultorio.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoConsultorio.Application", Version = "v1" });
            });
            services.AddCors(); // Make sure you call this previous to AddMvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                      (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<SqlServerContext>(); //contexto
            services.AddControllers().AddNewtonsoftJson(); //json
            services.AddMvc().AddNewtonsoftJson(opt =>
            {

                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            });
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoModel, Produto>();
                config.CreateMap<CategoriaModel, Categoria>();

                config.CreateMap<Produto, ProdutoModel>();
                config.CreateMap<Categoria, CategoriaModel>();

                config.CreateMap<Medico, MedicoModel>();
                config.CreateMap<MedicoModel, Medico>();

                config.CreateMap<Paciente, PacienteModel>();
                config.CreateMap<PacienteModel, Paciente>();

                config.CreateMap<Disponibilidade, DisponibilidadeModel>();
                config.CreateMap<DisponibilidadeModel, Disponibilidade>();


                config.CreateMap<MedicoDisponibilidade, MedicoDisponibilidadeModel>();
                config.CreateMap<MedicoDisponibilidadeModel, MedicoDisponibilidade>();

                config.CreateMap<Convenio, ConvenioModel>();
                config.CreateMap<ConvenioModel, Convenio>();

                config.CreateMap<MedicoConvenio, MedicoConvenioModel>();
                config.CreateMap<MedicoConvenioModel, MedicoConvenio>();

                config.CreateMap<ConsultaMedicoPaciente, ConsultaMedicoPacienteModel>();
                config.CreateMap<ConsultaMedicoPacienteModel, ConsultaMedicoPaciente>();

                config.CreateMap<StatusConsulta, StatusConsultaModel>();
                config.CreateMap<StatusConsultaModel, StatusConsulta>();

            }).CreateMapper());

            //injecao de dependia
            services.AddScoped<IBaseService<Categoria>, BaseService<Categoria>>();
            services.AddScoped<IBaseRepository<Categoria>, BaseRepository<Categoria>>();

            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();
            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();

            services.AddScoped<IBaseService<Medico>, BaseService<Medico>>();
            services.AddScoped<IBaseRepository<Medico>, BaseRepository<Medico>>();

            services.AddScoped<IBaseService<Paciente>, BaseService<Paciente>>();
            services.AddScoped<IBaseRepository<Paciente>, BaseRepository<Paciente>>();

            services.AddScoped<IBaseService<Disponibilidade>, BaseService<Disponibilidade>>();
            services.AddScoped<IBaseRepository<Disponibilidade>, BaseRepository<Disponibilidade>>();

            

            services.AddScoped<IBaseService<Convenio>, BaseService<Convenio>>();
            services.AddScoped<IBaseRepository<Convenio>, BaseRepository<Convenio>>();

            //services.AddScoped<IBaseService<MedicoConvenio>, BaseService<MedicoConvenio>>();
            //services.AddScoped<IBaseRepository<MedicoConvenio>, BaseRepository<MedicoConvenio>>();

            services.AddScoped<IBaseService<ConsultaMedicoPaciente>, BaseService<ConsultaMedicoPaciente>>();
            services.AddScoped<IBaseRepository<ConsultaMedicoPaciente>, BaseRepository<ConsultaMedicoPaciente>>();

            services.AddScoped<IBaseService<MedicoDisponibilidade>, BaseService<MedicoDisponibilidade>>();
            services.AddScoped<IBaseRepository<MedicoDisponibilidade>, BaseRepository<MedicoDisponibilidade>>();

            services.AddScoped<IBaseService<StatusConsulta>, BaseService<StatusConsulta>>();
            services.AddScoped<IBaseRepository<StatusConsulta>, BaseRepository<StatusConsulta>>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoConsultorio.Application v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseAuthentication();

            app.UseAuthorization();

            
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

    }
}
