using LinearTestPratico.Dominio.CanalVendaRoot;
using LinearTestPratico.Dominio.Core.Models;
using LinearTestPratico.Dominio.ProdutoRoot;

namespace LinearTestPratico.Dominio.CanalVendaProdutoRoot
{
    public class CanalVendaProduto : Entity
    {
        public int CanalVendaId { get; set; }
        public CanalVenda  CanalVenda { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
