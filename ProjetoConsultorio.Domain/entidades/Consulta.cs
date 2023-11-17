using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Consulta : BaseEntity
    {
       
        public DateTime data { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFim { get; set; }
        public int procedimentoId { get; set; }
        public int pacienteId { get; set; }
        public int convenioId { get; set; }
        public int statusConsultaId { get; set; }
        public int medicoId { get; set; }
        public virtual Procedimento procedimento { get; set; }
        public virtual Paciente paciente { get; set; }
        public virtual Convenio convenio { get; set; }
        public virtual StatusConsulta statusconsulta { get; set; }
        public virtual Medico medico { get; set; }


    }
}
