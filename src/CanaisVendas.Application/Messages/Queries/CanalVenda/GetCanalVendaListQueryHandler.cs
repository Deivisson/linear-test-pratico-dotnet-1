using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSistemas.CanaisVendas.Application.Messages.Queries.CanalVendaList
{
    public class GetCanalVendaListQueryHandler : IRequestHandler<GetCanalVendaListQuery, List<CanalVendaViewModel>>
    {
        private readonly ICanalVendaRepository _canalvendaRepository;
        private readonly IMapper _mapper;

        public GetCanalVendaListQueryHandler(ICanalVendaRepository canalvendaRepository, IMapper mapper)
        {
            _canalvendaRepository = canalvendaRepository ?? throw new ArgumentNullException(nameof(canalvendaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CanalVendaViewModel>> Handle(GetCanalVendaListQuery request, CancellationToken cancellationToken)
        {
            var canalList = await _canalvendaRepository.GetAllAsync();
            return _mapper.Map<List<CanalVendaViewModel>>(canalList);
        }
    }
}
