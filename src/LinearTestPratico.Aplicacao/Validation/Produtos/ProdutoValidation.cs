using FluentValidation;
using LinearTestPratico.Dominio.ProdutoRoot;

namespace LinearTestPratico.Aplicacao.Validation.Produtos
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            //RuleFor(p => p.CanaisVendas)
            //    .NotNull().WithMessage("O campo {PropertyName} é obrigatório.")
            //    .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que 0 (zero).");
        }
    }
}
