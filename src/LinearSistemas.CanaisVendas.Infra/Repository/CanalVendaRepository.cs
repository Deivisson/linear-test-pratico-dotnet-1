using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Domain.Models;
using LinearSistemas.CanaisVendas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace LinearSistemas.CanaisVendas.Infra.Repository
{
    public class CanalVendaRepository : Repository<CanalVenda>, ICanalVendaRepository
    {
        public CanalVendaRepository(VendasContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<CanalVenda>> GetCanalVendaByDescription(string description)
        {
            return await Db.CanaisVendas.Where(p => p.Descricao!.Contains(description))
                .ToListAsync();
        }
    }
}
