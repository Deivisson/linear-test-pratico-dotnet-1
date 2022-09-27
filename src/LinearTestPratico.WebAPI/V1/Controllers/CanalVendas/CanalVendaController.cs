using AutoMapper;
using LinearTestPartico.Infra.Data.Repository.Interfaces.CanalVendas;
using LinearTestPratico.Aplicacao.Interfaces.CanalVendas;
using LinearTestPratico.Aplicacao.Notificacoes.Interfaces;
using LinearTestPratico.Aplicacao.ViewModels.CanalVendas;
using LinearTestPratico.Dominio;
using LinearTestPratico.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LinearTestPratico.WebAPI.V1.Controllers.CanalVendas
{
    [Route("api/v1/canais-vendas")]
    [ApiController]
    public class CanalVendaController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICanalVendaRepository _repository;
        private readonly ICanalVendaService _service;

        public CanalVendaController(INotificador notificador,
            IMapper mapper,
            ICanalVendaRepository repository,
            ICanalVendaService service) : base(notificador)
        {
            this._mapper = mapper;
            this._repository = repository;
            this._service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CanalVendaExibirViewModel), 200)]
        [ProducesResponseType(typeof(BadRequestRetorno), 404)]
        public async Task<IActionResult> GetAsync()
        {
            var model = await _repository.ObterTodos();
            if (model == null)
                return NotFound();
            return CustomResponse(_mapper.Map<List<CanalVendaExibirViewModel>>(model));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CanalVendaAdicionarViewModel), 201)]
        [ProducesResponseType(typeof(BadRequestRetorno), 404)]
        public async Task<IActionResult> PostAsync([FromBody] CanalVendaAdicionarViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            int Id = await _service.Adicionar(viewmodel);

            if (!_notificador.TemNotificacao())
            {
                var modelsretorno = await _repository.ObterPorId(Id);
                var viewModelsRetorno = _mapper.Map<CanalVendaExibirViewModel>(modelsretorno);
                return CustomResponse(viewModelsRetorno);
            }

            return CustomResponse();
        }
    }
}