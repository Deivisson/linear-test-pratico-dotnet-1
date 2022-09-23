using MediatR;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.DeleteProduto
{
    public class DeleteProdutoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
