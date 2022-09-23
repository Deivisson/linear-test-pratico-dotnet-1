using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Application.Messages.Queries.CanalVendaList
{
    public class GetCanalVendaListQuery : IRequest<List<CanalVendaViewModel>>
    {
    }
}
