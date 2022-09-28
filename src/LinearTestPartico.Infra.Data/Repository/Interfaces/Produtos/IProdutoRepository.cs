using LinearTestPratico.Dominio.ProdutoRoot;

namespace LinearTestPartico.Infra.Data.Repository.Interfaces.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<List<Produto>> Buscar(string descricao);
    }
}
