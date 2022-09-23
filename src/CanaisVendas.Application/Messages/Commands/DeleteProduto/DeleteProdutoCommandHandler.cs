using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Exceptions;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.DeleteProduto
{
    internal class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteProdutoCommandHandler> _logger;

        public DeleteProdutoCommandHandler(IProdutoRepository produtoRepository,
            IMapper mapper, ILogger<DeleteProdutoCommandHandler> logger)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var model = await _produtoRepository.GetByIdAsync(request.Id);
            if (model == null)
            {
                throw new NotFoundException(nameof(Produto), request.Id);
            }

            await _produtoRepository.DeleteAsync(model.Id);
            _logger.LogInformation($"Produto {model.Id} excluido com sucesso.");

            return Unit.Value;
        }
    }
}
