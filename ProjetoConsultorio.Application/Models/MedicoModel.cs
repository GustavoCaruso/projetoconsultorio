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
        public DateTime dataNascimento { get; set; }
        public string genero { get; set; }
        public string enderecoResidencial { get; set; }
        public string numeroTelefone { get; set; }
        public string email { get; set; }
        public string crm { get; set; }
        public string especializacao { get; set; }

        public virtual ICollection<MedicoConvenio> medicoconvenio { get; set; }
        public virtual ICollection<MedicoDisponibilidade> medicodisponibilidade { get; set; }



    }
}
