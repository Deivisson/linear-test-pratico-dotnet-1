using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Exceptions;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.DeleteCanalVenda
{
    public class DeleteCanalVendaCommandHandler : IRequestHandler<DeleteCanalVendaCommand>
    {
        private readonly ICanalVendaRepository _canalRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCanalVendaCommandHandler> _logger;

        public DeleteCanalVendaCommandHandler(ICanalVendaRepository canalRepository,
            IMapper mapper, ILogger<DeleteCanalVendaCommandHandler> logger)
        {
            _canalRepository = canalRepository ?? throw new ArgumentNullException(nameof(canalRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteCanalVendaCommand request, CancellationToken cancellationToken)
        {
            var model = await _canalRepository.GetByIdAsync(request.Id);
            if (model == null)
            {
                throw new NotFoundException(nameof(CanalVenda), request.Id);
            }

            await _canalRepository.DeleteAsync(request.Id);
            _logger.LogInformation($"Canal de venda {model.Id} excluido com sucesso.");

            return Unit.Value;
        }
    }
}
