using AutoMapper;
using LinearTestPartico.Infra.Data.Repository.Interfaces.Produtos;
using LinearTestPratico.Aplicacao.AutoMapper;
using LinearTestPratico.Aplicacao.Notificacoes;
using LinearTestPratico.Aplicacao.Notificacoes.Interfaces;
using LinearTestPratico.Aplicacao.Services.Produtos;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Moq;
using Xunit;

namespace LinearTestPratico.Services.API.Tests.Services.Produtos
{

    public class ProdutoTests
    {
        private ProdutoService _service;
        private INotificador _notificador;


        public ProdutoTests()
        {
            var config = AutoMapperConfiguration.RegisterMappings();
            var _imapper = new Mock<IMapper>().Object;
            _notificador = new Notificador();
            _service = new ProdutoService(_notificador, new Mock<IProdutoRepository>().Object, config.CreateMapper());
        }

        [Fact]
        public async void Adiciona_validaNull()
        {
            int id = await   _service.Adicionar(new Aplicacao.ViewModels.Produtos.ProdutoAdicionarViewModel());

            bool retorno = !_notificador.TemNotificacao();

            foreach (var item in _notificador.ObterNotificacoes())
            {
                Assert.False(retorno, item.Mensagem);
            }
        }

        [Fact]
        public async void Adiciona_validaDescricao()
        {
            int[] ids = new int[]{1};
            var viewModel = new Aplicacao.ViewModels.Produtos.ProdutoAdicionarViewModel() { Descricao = "Coca-Cola", CanaisVendasIds = ids.ToList() };
            int id = await _service.Adicionar(viewModel);

            bool retorno = !_notificador.TemNotificacao();

            foreach (var item in _notificador.ObterNotificacoes())
            {
                Assert.True(retorno, item.Mensagem);
            }
        }

        [Fact]
        public async void Adiciona_validaNullCanaisVendaList()
        {
            var viewModel = new Aplicacao.ViewModels.Produtos.ProdutoAdicionarViewModel() { Descricao = "Coca-Cola"};
            int id = await _service.Adicionar(viewModel);

            bool retorno = !_notificador.TemNotificacao();

            foreach (var item in _notificador.ObterNotificacoes())
            {
                Assert.False(retorno, item.Mensagem);
            }
        }

        [Fact]
        public async void Adiciona_validaDescricaoMaximo50Caracteries()
        {
            var viewModel = new Aplicacao.ViewModels.Produtos.ProdutoAdicionarViewModel() { Descricao = "Descrição com mais de cinquenta caractéries.........." };
            int id = await _service.Adicionar(viewModel);

            bool retorno = !_notificador.TemNotificacao();

            foreach (var item in _notificador.ObterNotificacoes())
            {
                Assert.False(retorno, item.Mensagem);
            }
        }
    }
}
