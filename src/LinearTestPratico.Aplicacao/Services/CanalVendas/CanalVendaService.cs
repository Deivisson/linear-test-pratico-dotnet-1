using AutoMapper;
using LinearTestPartico.Infra.Data.Repository.Interfaces.CanalVendas;
using LinearTestPratico.Aplicacao.Interfaces.CanalVendas;
using LinearTestPratico.Aplicacao.Notificacoes.Interfaces;
using LinearTestPratico.Aplicacao.ViewModels.CanalVendas;
using LinearTestPratico.Dominio.CanalVendaRoot;

namespace LinearTestPratico.Aplicacao.Services.CanalVendas
{
    public class CanalVendaService : BaseService, ICanalVendaService
    {
        private readonly ICanalVendaRepository _repository;
        private readonly IMapper mapper;

        public CanalVendaService(INotificador notificador,
            ICanalVendaRepository repository,
            IMapper mapper) : base(notificador)
        {
            this._repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Adicionar(CanalVendaAdicionarViewModel viewmodel)
        {
            var model = mapper.Map<CanalVenda>(viewmodel);
            if (model==null)
            {
                Notificar("Canal de venda não pode ser nulo.");
                return 0;
            }

            if (model != null && string.IsNullOrEmpty(model.Descricao))
            {
                Notificar("Descrição do canal de venda, não pode ser nulo.");
                return 0;
            }

            if (model != null && model.Descricao.Length>20)
            {
                Notificar("Descrição do canal de venda, não pode ter mais de 20 caractéries.");
                return 0;
            }

            await _repository.Adicionar(model);
            return model.Id;
        }

        public Task Atualizar(CanalVendaAtualizarViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Remover(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
