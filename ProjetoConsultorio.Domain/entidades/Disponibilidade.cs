using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Disponibilidade: BaseEntity
    {
       
        public int diaDaSemana { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFim { get; set; }
        public bool disponivel { get; set; }
        public int medicoId { get; set; }
        public virtual Medico medico { get; set; }
        //public ICollection<MedicoDisponibilidade> medicodisponibilidade { get; set; }
    }
}
