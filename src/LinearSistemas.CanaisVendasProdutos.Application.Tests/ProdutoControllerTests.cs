using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto;
using LinearSistemas.CanaisVendas.Application.Messages.Queries.ProdutoList;
using LinearSistemas.CanaisVendas.Domain.Models;
using LinearSistemas.CanaisVendasProdutos.API.Controllers;
using LinearSistemas.CanaisVendasProdutos.Application.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LinearSistemas.CanaisVendasProdutos.Application.Tests
{
    public class ProdutoControllerTests
    {
        [Fact]
        public async void WhenGettingAllProdutos_ThenAllProdutosReturn()
        {
            var repositorycanalvenda = MockIProdutoRepository.GetMock();
            var mapper = MockerIMapper.GetMapper();
            var MediatorT = MockIProdutoRepository.GetMockMediatorQuery();

            var produtoController = new ProdutosController(MediatorT.Object);

            var retornoGet = await produtoController
                .Get(1);

            var result = await repositorycanalvenda.Object.GetAllAsync();

            MediatorT.Verify(x => x.Send(It.IsAny<GetProdutoQuery>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (retornoGet as OkObjectResult).StatusCode);
            Assert.IsAssignableFrom<IEnumerable<Produto>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GivenValidRequest_WhenCreatingProdutos_ThenCreatedReturns()
        {
            var repositorycanalvenda = MockIProdutoRepository.GetMock();
            var mapper = MockerIMapper.GetMapper();
            var MediatorT = MockIProdutoRepository.GetMockMediator();

            var produtoController = new ProdutosController(MediatorT.Object);

            var produto = new AddProdutoCommand()
            {
                Descricao = "Teste Unitario",
                CanaisVendasIds = new List<CanaisVendas.Application.ViewModels.CanalVenda.CanalVendaAdicionarViewModel>
                {
                    new CanaisVendas.Application.ViewModels.CanalVenda.CanalVendaAdicionarViewModel
                    {
                        Id = 1
                    },
                    new CanaisVendas.Application.ViewModels.CanalVenda.CanalVendaAdicionarViewModel
                    {
                        Id = 2
                    },
                }
            };

            var retornoPost = await produtoController
                .Post(produto);

            var result = await repositorycanalvenda.Object.AddAsync(new Produto { Id = 1, Descricao = "Teste", CanaisVendas = new List<ProdutoCanalVenda> { new ProdutoCanalVenda { CanalVendaId = 1 } } });

            MediatorT.Verify(x => x.Send(It.IsAny<AddProdutoCommand>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (retornoPost.Result as OkObjectResult).StatusCode);
            Assert.IsAssignableFrom<Produto>(result);
        }

        [Fact]
        public async void WhenGettingProdutosByDescription_ThenProdutoReturn()
        {
            var repositorycanalvenda = MockIProdutoRepository.GetMock();
            var mapper = MockerIMapper.GetMapper();
            var MediatorT = MockIProdutoRepository.GetMockMediatorQuery();

            var produtoController = new ProdutosController(MediatorT.Object);

            var retornoGet = await produtoController
                .GetPesquisa("Produto Teste");

            var result = await repositorycanalvenda.Object.GetProdutoByDescription("Produto Teste");

            MediatorT.Verify(x => x.Send(It.IsAny<GetProdutoListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (retornoGet.Result as OkObjectResult).StatusCode);
            Assert.IsAssignableFrom<IEnumerable<Produto>>(result);
            Assert.NotEmpty(result);
        }
    }
}
