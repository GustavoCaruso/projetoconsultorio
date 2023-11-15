using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Convenio: BaseEntity
    {

        public Convenio()
        {
            this.medicoconvenio = new HashSet<MedicoConvenio>();
            this.pacienteconvenio = new HashSet<PacienteConvenio>();
        }

        public string nome { get; set; }

        public virtual ICollection<MedicoConvenio> medicoconvenio { get; set; }
        public virtual ICollection<PacienteConvenio> pacienteconvenio { get; set; }

    }
}
