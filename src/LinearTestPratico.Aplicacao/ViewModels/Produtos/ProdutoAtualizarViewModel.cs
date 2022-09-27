using LinearTestPratico.Aplicacao.ViewModels.Base;
using LinearTestPratico.Aplicacao.ViewModels.CanalVendas;

namespace LinearTestPratico.Aplicacao.ViewModels.Produtos
{
    public class ProdutoAtualizarViewModel : BaseViewModel
    {
        public string Descricao { get; set; }
        public List<CanalVendaAtualizarViewModel> CanaisVendas { get; set; }
    }
}
