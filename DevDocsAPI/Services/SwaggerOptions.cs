using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace DevDocsAPI.Services
{
    public class SwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public SwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateApiInfo(description));
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private OpenApiInfo CreateApiInfo(ApiVersionDescription description)
        {
            OpenApiInfo openApiInfo = new OpenApiInfo()
            {
                Title = "DevDocsAPI",
                Version = description.ApiVersion.ToString(),
                Description = "Esta API tiene como fin obtener acceso directo a la documentación oficial a los lenguajes de programación en tendencia.",
                Contact = new OpenApiContact
                {
                    Email = "erick_h98@outlook.com",
                    Name = "Erick Hernández"
                }
            };

            if (description.IsDeprecated)
                openApiInfo.Description += " | This API has been deprecated";

            return openApiInfo;
        }
    }
}