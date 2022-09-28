using LinearTestPartico.Infra.Data.Context;
using LinearTestPartico.Infra.Data.Repository.CanalVendas;
using LinearTestPartico.Infra.Data.Repository.Interfaces.CanalVendas;
using LinearTestPartico.Infra.Data.Repository.Interfaces.Produtos;
using LinearTestPartico.Infra.Data.Repository.Produtos;
using LinearTestPratico.Aplicacao.Interfaces.CanalVendas;
using LinearTestPratico.Aplicacao.Interfaces.Produtos;
using LinearTestPratico.Aplicacao.Interfaces.Users;
using LinearTestPratico.Aplicacao.Notificacoes;
using LinearTestPratico.Aplicacao.Notificacoes.Interfaces;
using LinearTestPratico.Aplicacao.Services.CanalVendas;
using LinearTestPratico.Aplicacao.Services.Produtos;
using LinearTestPratico.Infra.CrossCutting.Identity.Authorization;
using LinearTestPratico.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LinearTestPratico.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET Authorization Polices -
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();

            #region Contextos
            services.AddScoped<ContextBase>();
            //services.AddScoped<ContextBaseIdentity>();
            #endregion

            services.AddScoped<IAspNetUser, AspNetUser>();

            #region Repositórios


            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<ICanalVendaRepository, CanalVendaRepository>();
            services.AddScoped<ICanalVendaService, CanalVendaService>();


            #endregion
        }
    }
}