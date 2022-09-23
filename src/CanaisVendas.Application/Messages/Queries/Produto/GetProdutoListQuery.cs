using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using MediatR;

namespace LinearSistemas.CanaisVendas.Application.Messages.Queries.ProdutoList
{
    public class GetProdutoListQuery : IRequest<List<ProdutoViewModel>>
    {
        public string? Descricao { get; set; }
        public GetProdutoListQuery(string descricao)
        {
            Descricao = descricao;
        }
    }
}
