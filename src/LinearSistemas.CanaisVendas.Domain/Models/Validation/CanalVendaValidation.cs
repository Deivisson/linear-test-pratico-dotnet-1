using FluentValidation;

namespace LinearSistemas.CanaisVendas.Domain.Models.Validation
{
    public class CanalVendaValidation : AbstractValidator<CanalVenda>
    {
        public CanalVendaValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(5, 20).WithMessage("O Campo {PropertyName} deve conter entre 5 e 20 caracteres.");
        }
    }
}
