using LinearTestPratico.Dominio.CanalVendaProdutoRoot;
using LinearTestPratico.Dominio.Core.Models;

namespace LinearTestPratico.Dominio.CanalVendaRoot
{
    public class CanalVenda : Entity
    {
        public string Descricao { get; set; }
        public List<CanalVendaProduto> CanaisVendas { get; set; }
    }
}
