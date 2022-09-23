using LinearSistemas.CanaisVendas.Domain.Models;

namespace LinearSistemas.CanaisVendas.Application.Persistence
{
    public interface ICanalVendaRepository : IRepository<CanalVenda>
    {
        Task<IEnumerable<CanalVenda>> GetCanalVendaByDescription(string description);
    }
}
