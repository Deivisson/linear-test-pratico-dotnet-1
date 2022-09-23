using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using MediatR;

namespace LinearSistemas.CanaisVendas.Application.Messages.Queries.ProdutoList
{
    public class GetProdutoQueryHandler : IRequestHandler<GetProdutoQuery, ProdutoViewModel>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public GetProdutoQueryHandler(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProdutoViewModel> Handle(GetProdutoQuery request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProdutoViewModel>(produto);
        }
    }
}
