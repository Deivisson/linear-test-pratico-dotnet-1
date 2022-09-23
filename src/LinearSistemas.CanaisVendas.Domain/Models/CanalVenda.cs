using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearSistemas.CanaisVendas.Domain.Models.Base;

namespace LinearSistemas.CanaisVendas.Domain.Models
{
    public class CanalVenda : Entity
    {
        public string? Descricao { get; set; }
        public virtual ICollection<ProdutoCanalVenda> CanaisVendas { get; set; }

        // EF
        //public virtual List<Produto>? Produtos { get; set; }

        //public Guid IdProduto { get; set; }
        //public virtual Produto? Produto { get; set; }
    }
}
