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
            this.medicoconvenio = new List<MedicoConvenio>();
        }
        public string nome { get; set; }
        public List<MedicoConvenio> medicoconvenio { get; set; }

    }
}
