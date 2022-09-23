using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using LinearSistemas.CanaisVendas.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda
{
    public class AddCanalVendaCommandHandler : IRequestHandler<AddCanalVendaCommand, CanalVendaViewModel>
    {
        private readonly ICanalVendaRepository _canalvendaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddCanalVendaCommandHandler> _logger;

        public AddCanalVendaCommandHandler(ICanalVendaRepository canalvendaRepository, IMapper mapper, ILogger<AddCanalVendaCommandHandler> logger)
        {
            _canalvendaRepository = canalvendaRepository ?? throw new ArgumentNullException(nameof(canalvendaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CanalVendaViewModel> Handle(AddCanalVendaCommand request, CancellationToken cancellationToken)
        {
            var novocanal = await _canalvendaRepository.AddAsync(_mapper.Map<CanalVenda>(request));

            _logger.LogInformation($"Canal de venda {novocanal.Descricao} foi criado com sucesso.");

            return _mapper.Map<CanalVendaViewModel>(novocanal);
        }
    }
}
