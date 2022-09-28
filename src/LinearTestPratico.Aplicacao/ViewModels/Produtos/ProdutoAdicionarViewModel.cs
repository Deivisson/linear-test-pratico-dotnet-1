using LinearTestPratico.Aplicacao.ViewModels.Base;

namespace LinearTestPratico.Aplicacao.ViewModels.Produtos
{
    public class ProdutoAdicionarViewModel 
    {
        public string Descricao { get; set; }
        public List<int> CanaisVendasIds { get; set; }
    }
}
