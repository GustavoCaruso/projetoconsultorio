using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Domain.entidades
{
    public class Produto:BaseEntity
    {
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public int qtde { get; set; }
        public DateTime datavalidade { get; set; }
        public int idCategoria { get; set; }
        public virtual Categoria categoria { get; set; }
    }
}
