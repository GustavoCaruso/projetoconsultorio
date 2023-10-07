using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Medico:BaseEntity
    {
        public Medico()
        {
            this.disponibilidade = new HashSet<Disponibilidade>();
            medicoconvenio = new List<MedicoConvenio>();
            consultamedicopaciente = new List<ConsultaMedicoPaciente>();
        }
        public string nome { get; set; }
        public string crm { get; set; }
        public string especializacao { get; set; }
        public virtual ICollection<Disponibilidade> disponibilidade { get; set; }
        public List<MedicoConvenio> medicoconvenio { get; set; }

        public List<ConsultaMedicoPaciente> consultamedicopaciente { get; set; }


        //public ICollection<MedicoDisponibilidade> medicodisponibilidade { get; set; }

        //public List<MedicoConsulta> medicoconsulta { get; set; }
    }
}
