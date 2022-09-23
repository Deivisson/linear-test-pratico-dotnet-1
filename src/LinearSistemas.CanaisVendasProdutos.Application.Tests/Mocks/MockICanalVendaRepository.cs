using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda;
using LinearSistemas.CanaisVendas.Application.Messages.Queries.CanalVendaList;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using LinearSistemas.CanaisVendas.Domain.Models;
using MediatR;
using Moq;

namespace LinearSistemas.CanaisVendasProdutos.Application.Tests.Mocks
{
    internal class MockICanalVendaRepository
    {
        public static Mock<ICanalVendaRepository> GetMock()
        {
            var mock = new Mock<ICanalVendaRepository>();

            var canalvenda = new List<CanalVenda>()
            {
                new CanalVenda() { Id = 1, Descricao = "Teste Unitarios" }
            };

            mock.Setup(c => c.GetAllAsync()).ReturnsAsync(() => canalvenda);

            mock.Setup(c => c.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => canalvenda.FirstOrDefault(v => v.Id == id));

            mock.Setup(c => c.AddAsync(It.IsAny<CanalVenda>())).ReturnsAsync(() => canalvenda.FirstOrDefault());

            mock.Setup(c => c.DeleteAsync(It.IsAny<int>())).Callback(() => { return; });

            mock.Setup(c => c.UpdateAsync(It.IsAny<CanalVenda>())).Callback(() => { return; });

            return mock;
        }

        public static Mock<IMediator> GetMockMediatorCommand()
        {
            var mock = new Mock<IMediator>();

            mock.Setup(c => c.Send(It.IsAny<AddCanalVendaCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CanalVendaViewModel { Descricao = "teste", Id = 1 });

            return mock;
        }

        public static Mock<IMediator> GetMockMediatorQuery()
        {
            var mock = new Mock<IMediator>();

            mock.Setup(c => c.Send(It.IsAny<GetCanalVendaListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<CanalVendaViewModel>());

            return mock;
        }
    }
}
