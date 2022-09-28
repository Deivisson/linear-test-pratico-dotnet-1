using AutoMapper;
using LinearTestPartico.Infra.Data.Repository.Interfaces.Produtos;
using LinearTestPratico.Aplicacao.Interfaces.Produtos;
using LinearTestPratico.Aplicacao.Notificacoes.Interfaces;
using LinearTestPratico.Aplicacao.ViewModels.Produtos;
using LinearTestPratico.Dominio;
using LinearTestPratico.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LinearTestPratico.WebAPI.V1.Controllers.Produto
{

    [Route("api/v1/produtos")]
    [ApiController]
    public class ProdutoConttroller : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _repository;
        private readonly IProdutoService _service;

        public ProdutoConttroller(INotificador notificador,
            IMapper mapper,
            IProdutoRepository repository,
            IProdutoService service) : base(notificador)
        {
            this._mapper = mapper;
            this._repository = repository;
            this._service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProdutoExibirViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 404)]
        public async Task<IActionResult> GetAsync()
        {
            var modelsretorno = await _repository.ObterTodos();
            if (modelsretorno == null)
                return NotFound();

            var viewModelsRetorno = _mapper.Map<List<ProdutoExibirViewModel>>(modelsretorno);

            foreach (var produto in modelsretorno)
            {
                foreach (var canalVenda in produto.CanaisVendas)
                {
                    var produtoView = viewModelsRetorno.Where(r => r.Id.Equals(produto.Id)).SingleOrDefault();
                    if (produtoView != null)
                        produtoView.CanaisVendas.Add(new Aplicacao.ViewModels.CanalVendas.CanalVendaExibirViewModel() { Descricao = canalVenda.CanalVenda.Descricao, Id = canalVenda.CanalVenda.Id });
                }
            }

            return CustomResponse(viewModelsRetorno);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoAdicionarViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 404)]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoAdicionarViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            int Id = await _service.Adicionar(viewmodel);

            if (!_notificador.TemNotificacao())
            {
                var modelsretorno = await _repository.ObterPorId(Id);
                var viewModelsRetorno = _mapper.Map<ProdutoExibirViewModel>(modelsretorno);
                foreach (var item in modelsretorno.CanaisVendas)
                {
                    viewModelsRetorno.CanaisVendas.Add(new Aplicacao.ViewModels.CanalVendas.CanalVendaExibirViewModel() { Descricao = item.CanalVenda.Descricao, Id = item.CanalVenda.Id });
                }
                return CustomResponse(viewModelsRetorno);
            }

            return CustomResponse();
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(typeof(ProdutoExibirViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 404)]
        public async Task<IActionResult> GetAsync(int Id)
        {
            var modelsretorno = await _repository.ObterPorId(Id);
            if(modelsretorno!=null)
            {
                var viewModelsRetorno = _mapper.Map<ProdutoExibirViewModel>(modelsretorno);

                foreach (var item in modelsretorno.CanaisVendas)
                {
                    viewModelsRetorno.CanaisVendas.Add(new Aplicacao.ViewModels.CanalVendas.CanalVendaExibirViewModel() { Descricao = item.CanalVenda.Descricao, Id = item.CanalVenda.Id });
                }

                return CustomResponse(viewModelsRetorno);
            }
            return CustomResponse();
        }

        [HttpGet("pesquisa")]
        [ProducesResponseType(typeof(ProdutoExibirViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 404)]
        public async Task<IActionResult> BuscaAsync([FromQuery] string descricao)
        {
            var modelsretorno = await _repository.Buscar(descricao);
            if (modelsretorno != null)
            {
                var viewModelsRetorno = _mapper.Map<List<ProdutoExibirViewModel>>(modelsretorno);

                foreach (var produto in modelsretorno)
                {
                    foreach (var canalVenda in produto.CanaisVendas)
                    {
                        var produtoView = viewModelsRetorno.Where(r => r.Id.Equals(produto.Id)).SingleOrDefault();
                        if(produtoView!=null)
                            produtoView.CanaisVendas.Add(new Aplicacao.ViewModels.CanalVendas.CanalVendaExibirViewModel() { Descricao = canalVenda.CanalVenda.Descricao, Id = canalVenda.CanalVenda.Id });
                    }
                }

                return CustomResponse(viewModelsRetorno);
            }
            return CustomResponse();
        }
    }
}
