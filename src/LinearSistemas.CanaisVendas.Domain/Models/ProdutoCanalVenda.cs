using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Domain.Models
{
    public class ProdutoCanalVenda
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int CanalVendaId { get; set; }
        public CanalVenda CanalVenda { get; set; }
    }
}
