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
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFim { get; set; }
      
       
    }
}
