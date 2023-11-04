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
            this.medicoconvenio = new List<MedicoConvenio>();
            this.consultamedicopaciente = new List<ConsultaMedicoPaciente>();
        }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string genero { get; set; }
        public string enderecoResidencial { get; set; }
        public string numeroTelefone { get; set; }
        public string email { get; set; }
        public string crm { get; set; }
        public string especializacao { get; set; }
        public virtual ICollection<Disponibilidade> disponibilidade { get; set; }
        public List<MedicoConvenio> medicoconvenio { get; set; }
        public List<ConsultaMedicoPaciente> consultamedicopaciente { get; set; }


        //public ICollection<MedicoDisponibilidade> medicodisponibilidade { get; set; }

        //public List<MedicoConsulta> medicoconsulta { get; set; }
    }
}
