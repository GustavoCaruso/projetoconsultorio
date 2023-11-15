using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Disponibilidade : BaseEntity
    {
        public Disponibilidade()
        {
            this.medicodisponibilidade = new HashSet<MedicoDisponibilidade>();
        }
        public int diaDaSemana { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFim { get; set; }


        public virtual ICollection<MedicoDisponibilidade> medicodisponibilidade { get; set; }

    }
}
