using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class PacienteModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string genero { get; set; }
        public string estadoCivil { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public virtual ICollection<PacienteConvenioModel> pacienteconvenio { get; set; }


    }
}
