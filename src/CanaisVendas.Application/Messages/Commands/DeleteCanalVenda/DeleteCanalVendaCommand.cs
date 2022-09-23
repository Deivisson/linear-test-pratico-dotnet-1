using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Application.Messages.Commands.DeleteCanalVenda
{
    public class DeleteCanalVendaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
