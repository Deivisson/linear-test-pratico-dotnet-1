using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto;
using LinearSistemas.CanaisVendas.Application.Messages.Queries.ProdutoList;
using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinearSistemas.CanaisVendasProdutos.API.Controllers
{
    [ApiController]
    [Route("produtos/")]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProdutoViewModel>> Post([FromBody] AddProdutoCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _mediator.Send(command);
            return result == null ? Ok(result) : RedirectToRoute("GetProdutos", new { id = result?.Id });
        }

        [HttpGet("pesquisa")]
        [ProducesResponseType(typeof(IEnumerable<ProdutoViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> GetPesquisa([FromQuery(Name = "descricao")] string? descricao)
        {
            if (!ModelState.IsValid) return BadRequest();
            var query = new GetProdutoListQuery(String.IsNullOrEmpty(descricao) ? "" : descricao);
            var produtos = await _mediator.Send(query);
            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "GetProdutos")]
        [ProducesResponseType(typeof(ProdutoViewModel), 200)]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var query = new GetProdutoQuery(id);
            var produto = await _mediator.Send(query);
            return Ok(produto);
        }
    }
}
