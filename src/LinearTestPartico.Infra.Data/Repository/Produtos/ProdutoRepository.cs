using LinearTestPartico.Infra.Data.Context;
using LinearTestPartico.Infra.Data.Repository.Base;
using LinearTestPartico.Infra.Data.Repository.Interfaces.Produtos;
using LinearTestPratico.Dominio.ProdutoRoot;
using Microsoft.EntityFrameworkCore;

namespace LinearTestPartico.Infra.Data.Repository.Produtos
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ContextBase context) : base(context)
        {
        }

        public override async Task<List<Produto>> ObterTodos()
        {
            var model = await this.Db.Produtos.AsNoTracking()
                .Include(r => r.CanaisVendas).ThenInclude(r => r.CanalVenda)
                .ToListAsync();
            return model;
        }

        public async Task<List<Produto>> Buscar(string descricao)
        {
            var model = await this.Db.Produtos.AsNoTracking()
                .Include(r => r.CanaisVendas).ThenInclude(r => r.CanalVenda)
                .Where(d => d.Descricao.Contains(descricao)).ToListAsync();
            return model;
        }

        public override async Task<Produto> ObterPorId(int id)
        {
            var model = await this.Db.Produtos.AsNoTracking()
                .Include(r=> r.CanaisVendas).ThenInclude(r=> r.CanalVenda)
                .Where(d => d.Id.Equals(id)).FirstOrDefaultAsync();
            return model;
        }

    }
}
