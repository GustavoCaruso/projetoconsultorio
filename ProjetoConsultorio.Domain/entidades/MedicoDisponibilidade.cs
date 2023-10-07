using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class MedicoDisponibilidade : BaseEntity
    {
        public int medicoId { get; set; }
        public Medico medico { get; set; }

        public int disponibilidadeId { get; set; }
        public Disponibilidade disponibilidade { get; set; }
    }
}
