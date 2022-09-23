using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda;
using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;

namespace LinearSistemas.CanaisVendasProdutos.Application.Tests
{
    public class ValidationTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("ss", false)]
        [InlineData("sswswswswswswswsw", true)]
        public void TestModelValidation(string? descricao, bool isValid)
        {
            var canalvenda = new AddCanalVendaCommand()
            {
                Descricao = descricao
            };

            Assert.Equal(isValid, ValidateModelAddCanal(canalvenda));
        }

        private bool ValidateModelAddCanal(AddCanalVendaCommand model)
        {
            var validation = new AddCanalVendaCommandValidation();
            var validationresult = validation.Validate(model);
            return validationresult.IsValid;
        }

        private bool ValidateModelAddProduto(AddProdutoCommand model)
        {
            var validation = new AddProdutoCommandValidation();
            var validationresult = validation.Validate(model);
            return validationresult.IsValid;
        }

        [Theory]
        [InlineData(null, null, false)]
        [InlineData("", null, false)]
        [InlineData("ss", null, false)]
        [InlineData("sswswswswswswswsw", null, false)]
        public void TestModelValidationProduto(string? descricao, List<CanalVendaAdicionarViewModel> canalid, bool isValid)
        {
            var produto = new AddProdutoCommand()
            {
                Descricao = descricao,
                CanaisVendasIds = canalid// new List<CanalVendaAdicionarViewModel>()
            };

            Assert.Equal(isValid, ValidateModelAddProduto(produto));
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("sss", true)]
        [InlineData("sswswswswswswswsw", true)]
        [InlineData("swswswswswswswswswswswswswswswswswswswswswswswswsww", false)]
        public void TestModelValidationProdutoLista(string? descricao, bool isValid)
        {
            var produto = new AddProdutoCommand()
            {
                Descricao = descricao,
                CanaisVendasIds = new List<CanalVendaAdicionarViewModel>()
                {
                    new CanalVendaAdicionarViewModel()
                    {
                        Id = 1
                    },
                    new CanalVendaAdicionarViewModel()
                    {
                        Id = 2
                    }
                }
            };

            Assert.Equal(isValid, ValidateModelAddProduto(produto));
        }
    }
}
