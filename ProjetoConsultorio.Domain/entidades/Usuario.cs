using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Usuario:BaseEntity
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
