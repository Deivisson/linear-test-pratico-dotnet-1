using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using MediatR;

namespace LinearSistemas.CanaisVendas.Application.Messages.Queries.ProdutoList
{
    public class GetProdutoListQueryHandler : IRequestHandler<GetProdutoListQuery, List<ProdutoViewModel>>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public GetProdutoListQueryHandler(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ProdutoViewModel>> Handle(GetProdutoListQuery request, CancellationToken cancellationToken)
        {
            var produto = string.IsNullOrEmpty(request.Descricao!.Replace("'", "")) ? await _produtoRepository.GetAllAsync() : await _produtoRepository.GetProdutoByDescription(request.Descricao!);
            return _mapper.Map<List<ProdutoViewModel>>(produto);
        }
    }
}
