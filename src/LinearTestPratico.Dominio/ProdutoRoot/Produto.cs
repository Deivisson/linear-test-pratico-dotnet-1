using LinearTestPratico.Dominio.CanalVendaProdutoRoot;
using LinearTestPratico.Dominio.Core.Models;

namespace LinearTestPratico.Dominio.ProdutoRoot
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public List<CanalVendaProduto> CanaisVendas { get; set; }
    }
}
