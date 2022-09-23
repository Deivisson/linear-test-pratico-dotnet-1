using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Domain.Models.Validation
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 50).WithMessage("O Campo {PropertyName} deve conter entre 3 e 50 caracteres.");

    //        RuleForEach(model => model.CanaisVendas)
    //.NotNull()
    //.WithMessage("Please fill all items");
        }
    }
}
