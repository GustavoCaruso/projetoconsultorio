using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class ConsultaMedicoPaciente : BaseEntity
    {
       
        public int medicoId { get; set; }
        public Medico Medico { get; set; }
        public int pacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataHora { get; set; }
    }
}
