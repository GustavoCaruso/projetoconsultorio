using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Procedimento : BaseEntity
    {
        public Procedimento()
        {
            this.consulta = new HashSet<Consulta>();
        }
       
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int duracao { get; set; }

        public virtual ICollection<Consulta> consulta { get; set; }
    }
}
