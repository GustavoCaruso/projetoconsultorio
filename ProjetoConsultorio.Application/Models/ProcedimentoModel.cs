using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class ProcedimentoModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int duracao { get; set; }
    }
}
