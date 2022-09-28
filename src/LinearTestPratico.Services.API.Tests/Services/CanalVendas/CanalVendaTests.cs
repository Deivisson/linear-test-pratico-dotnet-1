using AutoMapper;
using LinearTestPartico.Infra.Data.Repository.Interfaces.CanalVendas;
using LinearTestPratico.Aplicacao.AutoMapper;
using LinearTestPratico.Aplicacao.Notificacoes;
using LinearTestPratico.Aplicacao.Notificacoes.Interfaces;
using LinearTestPratico.Aplicacao.Services.CanalVendas;
using Moq;
using Xunit;

namespace LinearTestPratico.Services.API.Tests.Services.CanalVendas
{

    public class CanalVendaTests
    {
        private CanalVendaService _service;
        private INotificador _notificador;


        public CanalVendaTests()
        {
            var config = AutoMapperConfiguration.RegisterMappings();
            var _imapper = new Mock<IMapper>().Object;
            _notificador = new Notificador();
            _service = new CanalVendaService(_notificador, new Mock<ICanalVendaRepository>().Object, config.CreateMapper());
        }

        [Fact]
        public async void Adiciona_validaNull()
        {
            int id = await   _service.Adicionar(new Aplicacao.ViewModels.CanalVendas.CanalVendaAdicionarViewModel());

            bool retorno = !_notificador.TemNotificacao();

            foreach (var item in _notificador.ObterNotificacoes())
            {
                Assert.False(retorno, item.Mensagem);
            }
        }

        [Fact]
        public async void Adiciona_validaDescricao()
        {
            var viewModel = new Aplicacao.ViewModels.CanalVendas.CanalVendaAdicionarViewModel() { Descricao = "E-Commerce" };
            int id = await _service.Adicionar(viewModel);

            bool retorno = !_notificador.TemNotificacao();

            foreach (var item in _notificador.ObterNotificacoes())
            {
                Assert.True(retorno, item.Mensagem);
            }
        }

        [Fact]
        public async void Adiciona_validaDescricaoMaximo20Caracteries()
        {
            var viewModel = new Aplicacao.ViewModels.CanalVendas.CanalVendaAdicionarViewModel() { Descricao = "Descrição com mais de vinte caractéries" };
            int id = await _service.Adicionar(viewModel);

            bool retorno = !_notificador.TemNotificacao();

            foreach (var item in _notificador.ObterNotificacoes())
            {
                Assert.False(retorno, item.Mensagem);
            }
        }
    }
}
