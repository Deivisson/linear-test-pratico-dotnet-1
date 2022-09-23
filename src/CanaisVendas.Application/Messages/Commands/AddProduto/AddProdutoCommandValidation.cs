using FluentValidation;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto
{
    public class AddProdutoCommandValidation : AbstractValidator<AddProdutoCommand>
    {
        public AddProdutoCommandValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 50).WithMessage("O Campo {PropertyName} deve conter entre 3 e 50 caracteres.");

            RuleFor(c => c.CanaisVendasIds).NotNull().NotEmpty().WithMessage("Lista de canais de vendas preenchimento obrigatório");

            RuleForEach(p => p.CanaisVendasIds).ChildRules(child =>
            {
                child.RuleFor(x => x.Id).NotNull()
                  .WithMessage("Lista de canais de vendas preenchimento obrigatório").GreaterThan(0);
            });
        }

        public class CanalValidator : AbstractValidator<CanalVendaAdicionarViewModel>
        {
            public CanalValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }
    }
}
