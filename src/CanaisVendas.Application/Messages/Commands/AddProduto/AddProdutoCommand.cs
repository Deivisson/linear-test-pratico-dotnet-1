using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using MediatR;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto
{
    public class AddProdutoCommand : IRequest<ProdutoViewModel>
    {
        public string? Descricao { get; set; }
        public virtual List<CanalVendaAdicionarViewModel>? CanaisVendasIds { get; set; }
    }
}
