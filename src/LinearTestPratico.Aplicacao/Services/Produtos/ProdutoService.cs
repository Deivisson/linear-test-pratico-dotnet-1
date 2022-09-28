using AutoMapper;
using LinearTestPartico.Infra.Data.Repository.Interfaces.Produtos;
using LinearTestPratico.Aplicacao.Interfaces.Produtos;
using LinearTestPratico.Aplicacao.Notificacoes.Interfaces;
using LinearTestPratico.Aplicacao.ViewModels.Produtos;
using LinearTestPratico.Dominio.ProdutoRoot;

namespace LinearTestPratico.Aplicacao.Services.Produtos
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper mapper;

        public ProdutoService(INotificador notificador,
            IProdutoRepository repository,
            IMapper mapper) : base(notificador)
        {
            this._repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Adicionar(ProdutoAdicionarViewModel viewmodel)
        {
            var model = mapper.Map<Produto>(viewmodel);
            if (viewmodel == null)
            {
                Notificar("Produto não pode ser nulo.");
                return 0;
            }

            if (viewmodel != null && string.IsNullOrEmpty(viewmodel.Descricao))
            {
                Notificar("Descrição do produto, não pode ser nulo");
                return 0;
            }

            if (viewmodel != null && viewmodel.Descricao.Length>50)
            {
                Notificar("Descrição do produto, não pode maior que 50 caractéries.");
                return 0;
            }

            if (viewmodel != null && viewmodel.CanaisVendasIds == null || viewmodel.CanaisVendasIds.Count==0)
            {
                Notificar("Adicione ao menos 1 ou mais canais de vendas.");
                return 0;
            }

            model.CanaisVendas = new List<Dominio.CanalVendaProdutoRoot.CanalVendaProduto>();

            foreach (var item in viewmodel.CanaisVendasIds)
            {
                model.CanaisVendas.Add(new Dominio.CanalVendaProdutoRoot.CanalVendaProduto() { CanalVendaId = item, Produto = model });
            }

            await _repository.Adicionar(model);
            return model.Id;
        }

        public Task Atualizar(ProdutoAtualizarViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
