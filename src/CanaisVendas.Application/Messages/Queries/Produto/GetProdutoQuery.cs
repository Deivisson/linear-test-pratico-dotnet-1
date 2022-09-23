using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using MediatR;

namespace LinearSistemas.CanaisVendas.Application.Messages.Queries.ProdutoList
{
    public class GetProdutoQuery : IRequest<ProdutoViewModel>
    {
        public int Id { get; set; }
        public GetProdutoQuery(int id)
        {
            Id = id;
        }
    }
}
