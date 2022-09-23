using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Domain.Models;
using LinearSistemas.CanaisVendas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace LinearSistemas.CanaisVendas.Infra.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(VendasContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Produto>> GetProdutoByDescription(string description)
        {
            return await Db.Produtos.Include(c => c.CanaisVendas).ThenInclude(r => r.CanalVenda).Where(p => p.Descricao!.Contains(description))
                 .ToListAsync();
        }

        public override Task<Produto> GetByIdAsync(int id)
        {
            return Db.Produtos.Include(c => c.CanaisVendas).ThenInclude(r => r.CanalVenda).Where(p => p.Id.Equals(id)).FirstOrDefaultAsync()!;
        }

        public override async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await Db.Produtos.Include(c => c.CanaisVendas).ThenInclude(r => r.CanalVenda).ToListAsync();
        }
    }
}
