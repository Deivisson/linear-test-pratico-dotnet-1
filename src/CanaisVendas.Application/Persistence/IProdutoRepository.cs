using LinearSistemas.CanaisVendas.Domain.Models;

namespace LinearSistemas.CanaisVendas.Application.Persistence
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutoByDescription(string description);
    }
}
