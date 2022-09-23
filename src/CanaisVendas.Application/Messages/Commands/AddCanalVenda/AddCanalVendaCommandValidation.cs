using FluentValidation;
using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda
{
    public class AddCanalVendaCommandValidation : AbstractValidator<AddCanalVendaCommand>
    {
        public AddCanalVendaCommandValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(5, 20).WithMessage("O Campo {PropertyName} deve conter entre 5 e 20 caracteres.");
        }
    }
}
