using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using MediatR;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda
{
    public class AddCanalVendaCommand : IRequest<CanalVendaViewModel>
    {
        public string? Descricao { get; set; }
    }
}
