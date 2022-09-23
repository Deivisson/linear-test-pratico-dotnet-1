using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto;
using LinearSistemas.CanaisVendas.Application.Messages.Queries.ProdutoList;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using LinearSistemas.CanaisVendas.Domain.Models;
using MediatR;
using Moq;

namespace LinearSistemas.CanaisVendasProdutos.Application.Tests.Mocks
{
    internal class MockIProdutoRepository
    {
        public static Mock<IProdutoRepository> GetMock()
        {
            var mock = new Mock<IProdutoRepository>();

            var produto = new List<Produto>()
            {
                new Produto()
                {
                    Id = 1,
                    Descricao = "Produto Teste unitario",
                    CanaisVendas = new List<ProdutoCanalVenda>()
                    {
                        new ProdutoCanalVenda()
                        {
                            CanalVendaId = 1
                        },
                        new ProdutoCanalVenda()
                        {
                            CanalVendaId = 2
                        }
                    }
                }
            };

            mock.Setup(c => c.GetAllAsync()).ReturnsAsync(() => produto);

            mock.Setup(c => c.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => produto.FirstOrDefault(v => v.Id == id));

            mock.Setup(c => c.GetProdutoByDescription(It.IsAny<string>())).ReturnsAsync((string descricao) => produto.Where(v => v.Descricao!.Contains(descricao)));

            mock.Setup(c => c.AddAsync(It.IsAny<Produto>())).ReturnsAsync(() => produto.FirstOrDefault());

            mock.Setup(c => c.DeleteAsync(It.IsAny<int>())).Callback(() => { return; });

            mock.Setup(c => c.UpdateAsync(It.IsAny<Produto>())).Callback(() => { return; });

            return mock;
        }

        public static Mock<IMediator> GetMockMediator()
        {
            var mock = new Mock<IMediator>();

            mock.Setup(c => c.Send(It.IsAny<AddProdutoCommand>(), It.IsAny<CancellationToken>()));

            return mock;
        }

        public static Mock<IMediator> GetMockMediatorQuery()
        {
            var mock = new Mock<IMediator>();

            mock.Setup(c => c.Send(It.IsAny<GetProdutoListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<ProdutoViewModel>());

            return mock;
        }
    }
}
