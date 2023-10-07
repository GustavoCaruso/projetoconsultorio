using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class DisponibilidadeModel
    {
        public int id { get; set; }
        public int diaDaSemana { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFim { get; set; }
        public bool disponivel { get; set; }
        public int medicoId { get; set; }
        public Medico medico { get; set; }
        //public ICollection<MedicoDisponibilidade> medicodisponibilidade { get; set; }
    }
}
