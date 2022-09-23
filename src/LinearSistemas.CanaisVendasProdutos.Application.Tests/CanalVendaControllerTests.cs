using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda;
using LinearSistemas.CanaisVendas.Application.Messages.Queries.CanalVendaList;
using LinearSistemas.CanaisVendas.Domain.Models;
using LinearSistemas.CanaisVendasProdutos.API.Controllers;
using LinearSistemas.CanaisVendasProdutos.Application.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LinearSistemas.CanaisVendasProdutos.Application.Tests
{
    public class CanalVendaControllerTests
    {
        [Fact]
        public async void WhenGettingAllCanalVenda_ThenAllCanalVendaReturn()
        {
            var repositorycanalvenda = MockICanalVendaRepository.GetMock();
            var mapper = MockerIMapper.GetMapper();
            var MediatorT = MockICanalVendaRepository.GetMockMediatorQuery();

            var canalvendaController = new CanalVendaController(MediatorT.Object);

            var retornoGet = await canalvendaController
                .Get();

            var result = await repositorycanalvenda.Object.GetAllAsync();

            MediatorT.Verify(x => x.Send(It.IsAny<GetCanalVendaListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (retornoGet.Result as OkObjectResult).StatusCode);
            Assert.IsAssignableFrom<IEnumerable<CanalVenda>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GivenValidRequest_WhenCreatingCanalVenda_ThenCreatedReturns()
        {
            var repositorycanalvenda = MockICanalVendaRepository.GetMock();
            var mapper = MockerIMapper.GetMapper();
            var MediatorT = MockICanalVendaRepository.GetMockMediatorCommand();

            var canalvendaController = new CanalVendaController(MediatorT.Object);

            var canalvenda = new AddCanalVendaCommand()
            {
                Descricao = "Teste Unitario"
            };

            var retornoPost = await canalvendaController
                .Post(canalvenda);

            var result = await repositorycanalvenda.Object.AddAsync(new CanalVenda { Id = 1, Descricao = "Teste" });

            MediatorT.Verify(x => x.Send(It.IsAny<AddCanalVendaCommand>(), It.IsAny<CancellationToken>()), Times.Once());
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (retornoPost.Result as OkObjectResult).StatusCode);
            Assert.IsAssignableFrom<CanalVenda>(result);
        }
    }
}
