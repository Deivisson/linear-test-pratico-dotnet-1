using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearSistemas.CanaisVendas.Domain.Models.Base;

namespace LinearSistemas.CanaisVendas.Domain.Models
{
    public class Produto : Entity
    {
        public string? Descricao { get; set; }

        // EF
        public virtual List<ProdutoCanalVenda> CanaisVendas { get; set; } = new List<ProdutoCanalVenda>();
    }
}
