using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Application.ViewModels
{
    public class ProdutoCanalVendaViewModel
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        //public virtual List<CanalViewModel>? CanaisVendas { get; set; }
    }
}
