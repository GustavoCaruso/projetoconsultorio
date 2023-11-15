using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class PacienteConvenioModel
    {
        public int id { get; set; }
        public int pacienteId { get; set; }
        public int convenioId { get; set; }
    }
}
