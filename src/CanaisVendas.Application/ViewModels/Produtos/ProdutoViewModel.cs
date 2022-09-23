using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;

namespace LinearSistemas.CanaisVendas.Application.ViewModels.Produtos
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public virtual List<CanalVendaViewModel>? CanaisVendas { get; set; }
    }
}
