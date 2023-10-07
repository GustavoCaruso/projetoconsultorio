using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Categoria: BaseEntity
    {
        public Categoria()
        {
            this.produtos = new HashSet<Produto>();
        }
        public string descricao { get; set; }
        public virtual ICollection<Produto> produtos { get; set; }
    }
}
