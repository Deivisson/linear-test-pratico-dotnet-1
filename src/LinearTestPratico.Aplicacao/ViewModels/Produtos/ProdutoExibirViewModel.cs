using LinearTestPratico.Aplicacao.ViewModels.Base;
using LinearTestPratico.Aplicacao.ViewModels.CanalVendas;

namespace LinearTestPratico.Aplicacao.ViewModels.Produtos
{
    public class ProdutoExibirViewModel : BaseViewModel
    {
        public ProdutoExibirViewModel()
        {
            CanaisVendas = new List<CanalVendaExibirViewModel>();
        }

        public string Descricao { get; set; }
        public List<CanalVendaExibirViewModel> CanaisVendas { get; set; }
    }
}
