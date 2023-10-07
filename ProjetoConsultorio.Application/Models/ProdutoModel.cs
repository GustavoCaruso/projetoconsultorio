using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Models
{
    public class ProdutoModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public int qtde { get; set; }
        public DateTime datavalidade { get; set; }
        public int idCategoria { get; set; }
        public virtual CategoriaModel categoria { get; set; }
    }
}
