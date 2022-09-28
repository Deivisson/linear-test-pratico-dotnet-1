using LinearTestPratico.Aplicacao.ViewModels.CanalVendas;
using LinearTestPratico.Dominio.CanalVendaRoot;

namespace LinearTestPratico.Aplicacao.Interfaces.CanalVendas
{
    public interface ICanalVendaService : IDisposable
    {
        Task<int> Adicionar(CanalVendaAdicionarViewModel model);
        Task Atualizar(CanalVendaAtualizarViewModel model);
        Task Remover(int id);
    }
}
