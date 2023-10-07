using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public  class Paciente : BaseEntity
    {
        public Paciente()
        {
            consultamedicopaciente = new List<ConsultaMedicoPaciente>();
        }

        public string nome { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string genero { get; set; }
        public string estadoCivil { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public List<ConsultaMedicoPaciente> consultamedicopaciente { get; set; }
        // public List<Consulta> consulta { get; set; }
    }
}
