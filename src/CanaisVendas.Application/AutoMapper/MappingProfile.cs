using AutoMapper;
using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddCanalVenda;
using LinearSistemas.CanaisVendas.Application.Messages.Commands.AddProduto;
using LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda;
using LinearSistemas.CanaisVendas.Application.ViewModels.Produtos;
using LinearSistemas.CanaisVendas.Domain.Models;

namespace LinearSistemas.CanaisVendas.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Produto, AddProdutoCommand>().ReverseMap();
            CreateMap<ProdutoViewModel, AddProdutoCommand>().ReverseMap();

            CreateMap<CanalVenda, CanalVendaViewModel>().ReverseMap();
            CreateMap<CanalVenda, AddCanalVendaCommand>().ReverseMap();
            CreateMap<CanalVendaViewModel, AddCanalVendaCommand>().ReverseMap();

            CreateMap<CanalVendaViewModel, ProdutoCanalVenda>().ReverseMap();

            CreateMap<ProdutoCanalVenda, CanalVendaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>()
               .ForMember(dto => dto.CanaisVendas, opt => opt.MapFrom(x => x.CanaisVendas.Select(e => e.CanalVenda).ToList()));
        }
    }
}
