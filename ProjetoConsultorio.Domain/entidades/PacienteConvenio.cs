using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class PacienteConvenio : BaseEntity
    {
        public int pacienteId { get; set; }
        public int convenioId { get; set; }

        public virtual Convenio convenio { get; set; }
        public virtual Paciente paciente { get; set; }
    }
}
