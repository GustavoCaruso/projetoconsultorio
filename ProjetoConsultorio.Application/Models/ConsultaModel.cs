using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class ConsultaModel
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFim { get; set; }
        public int procedimentoId { get; set; }
        public int pacienteId { get; set; }
        public int convenioId { get; set; }
        public int statusConsultaId { get; set; }
        public int medicoId { get; set; }
        public Procedimento procedimento { get; set; }
        public Paciente paciente { get; set; }
        public Convenio convenio { get; set; }
        public StatusConsulta statusconsulta { get; set; }
        public Medico medico { get; set; }
    }
}
