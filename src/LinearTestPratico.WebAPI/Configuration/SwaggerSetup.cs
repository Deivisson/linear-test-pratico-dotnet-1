using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace LinearTestPratico.WebAPI.Configuration
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Linear Test Prático API",
                    Description = "Documentação da API - Linear Test Prático",
                    Contact = new OpenApiContact { Name = "Linear Test Prático", Email = "lineartestpratico.netcore.com", Url = new Uri("https://www.lineartestpratico.netcore.com") }
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}
