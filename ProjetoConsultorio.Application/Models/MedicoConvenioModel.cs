using ProjetoConsultorio.Domain.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class MedicoConvenioModel
    {
        
        public int medicoId { get; set; }
        public Medico medico { get; set; }

        public int convenioId { get; set; }
        public Convenio convenio { get; set; }
    }
}
