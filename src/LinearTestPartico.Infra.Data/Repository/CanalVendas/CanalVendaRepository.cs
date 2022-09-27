using LinearTestPartico.Infra.Data.Context;
using LinearTestPartico.Infra.Data.Repository.Base;
using LinearTestPartico.Infra.Data.Repository.Interfaces.CanalVendas;
using LinearTestPratico.Dominio.CanalVendaRoot;

namespace LinearTestPartico.Infra.Data.Repository.CanalVendas
{
    public class CanalVendaRepository : Repository<CanalVenda>, ICanalVendaRepository
    {
        public CanalVendaRepository(ContextBase context) : base(context)
        {
        }
    }
}
