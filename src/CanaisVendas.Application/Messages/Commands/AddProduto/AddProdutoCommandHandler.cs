using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using LinearSistemas.CanaisVendas.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto
{
    internal class AddProdutoCommandHandler : IRequestHandler<AddProdutoCommand, ProdutoViewModel>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddProdutoCommandHandler> _logger;

        public AddProdutoCommandHandler(IProdutoRepository produtoRepository, IMapper mapper, ILogger<AddProdutoCommandHandler> logger)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ProdutoViewModel> Handle(AddProdutoCommand request, CancellationToken cancellationToken)
        {
            var novoproduto = _mapper.Map<Produto>(request);
            novoproduto.CanaisVendas = new List<ProdutoCanalVenda>();

            foreach (var item in request.CanaisVendasIds!)
            {
                if (!novoproduto.CanaisVendas.Any(e => e.CanalVendaId.Equals(item.Id)))
                    novoproduto.CanaisVendas.Add(new ProdutoCanalVenda { CanalVendaId = item.Id });
            }

            await _produtoRepository.AddAsync(novoproduto);

            _logger.LogInformation($"Produto {novoproduto.Descricao} foi criado com sucesso.");

            return _mapper.Map<ProdutoViewModel>(novoproduto);
        }
    }
}
