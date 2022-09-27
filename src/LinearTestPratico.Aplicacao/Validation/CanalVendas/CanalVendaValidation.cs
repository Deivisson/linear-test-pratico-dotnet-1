using FluentValidation;
using LinearTestPratico.Dominio.CanalVendaRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearTestPratico.Aplicacao.Validation.CanalVendas
{
    public class CanalVendaValidation : AbstractValidator<CanalVenda>
    {
        public CanalVendaValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
               .Length(5, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
