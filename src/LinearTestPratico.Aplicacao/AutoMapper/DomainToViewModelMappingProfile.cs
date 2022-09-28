using AutoMapper;
using LinearTestPratico.Aplicacao.ViewModels.CanalVendas;
using LinearTestPratico.Aplicacao.ViewModels.Produtos;
using LinearTestPratico.Dominio.CanalVendaRoot;
using LinearTestPratico.Dominio.ProdutoRoot;

namespace LinearTestPratico.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CanalVenda, CanalVendaAdicionarViewModel>().ReverseMap();
            CreateMap<CanalVenda, CanalVendaExibirViewModel>().ReverseMap();
            CreateMap<CanalVenda, CanalVendaAtualizarViewModel>().ReverseMap();

            CreateMap<Produto, ProdutoAdicionarViewModel>()
                .ForMember(r => r.CanaisVendasIds, a => a.Ignore())
                .ReverseMap();

            CreateMap<Produto, ProdutoExibirViewModel>()
                .ForMember(r=> r.CanaisVendas, a => a.Ignore())
                .ReverseMap();

            CreateMap<Produto, ProdutoAtualizarViewModel>().ReverseMap();
        }
    }
}