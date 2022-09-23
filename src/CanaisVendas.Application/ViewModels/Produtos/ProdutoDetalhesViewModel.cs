using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Application.ViewModels.Produtos
{
    public class ProdutoDetalhesViewModel
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public virtual List<CanalVendaViewModel>? CanaisVendas { get; set; }
    }
}
