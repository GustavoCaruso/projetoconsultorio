using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class MedicoModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string crm { get; set; }
        public string especializacao { get; set; }

        [JsonIgnore]
        public List<MedicoConvenio> medicoconvenio { get; set; }
        [JsonIgnore]
        public List<ConsultaMedicoPaciente> consultamedicopaciente { get; set; }
        //public ICollection<MedicoDisponibilidade> medicodisponibilidade { get; set; }
    }
}
