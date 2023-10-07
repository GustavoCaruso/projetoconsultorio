using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class ConvenioModel
    {
        public int id { get; set; }
        public string nome { get; set; }

        [JsonIgnore]
        public List<MedicoConvenio> medicoConvenio { get; set; }
    }
}
