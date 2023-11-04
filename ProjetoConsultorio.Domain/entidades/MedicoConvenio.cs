using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class MedicoConvenio : BaseEntity
    {
        public int medicoId { get; set; }
        public Medico medico { get; set; }
        public int convenioId { get; set; }
        public Convenio convenio { get; set; }

    }
}
