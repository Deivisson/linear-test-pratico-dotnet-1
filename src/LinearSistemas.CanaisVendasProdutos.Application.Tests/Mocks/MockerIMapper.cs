using AutoMapper;
using LinearSistemas.CanaisVendas.Application.AutoMapper;

namespace LinearSistemas.CanaisVendasProdutos.Application.Tests.Mocks
{
    internal class MockerIMapper
    {
        public static IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(m => m.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }
    }
}
