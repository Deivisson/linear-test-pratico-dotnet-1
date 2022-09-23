using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda;
using LinearSistemas.CanaisVendas.Application.Messages.Queries.CanalVendaList;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinearSistemas.CanaisVendasProdutos.API.Controllers
{
    [ApiController]
    [Route("canais-vendas")]
    public class CanalVendaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CanalVendaController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(CanalVendaViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CanalVendaViewModel>> Post([FromBody] AddCanalVendaCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<CanalVendaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CanalVendaViewModel>>> Get()
        {
            var query = new GetCanalVendaListQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
    }
}
