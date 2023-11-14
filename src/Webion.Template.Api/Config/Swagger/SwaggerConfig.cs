using System.Reflection;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
namespace Qubi.Api.Config.Swagger;

public sealed class SwaggerConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services.ConfigureOptions<ApiVersioningOptions>();
        builder.Services.ConfigureOptions<BearerSecurityOptions>();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            options.CustomSchemaIds(x => x.FullName);
        });

        builder.Services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.SubstituteApiVersionInUrl = true;
        });
    }

    public void Use(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    url: $"{description.GroupName}/swagger.json",
                    name: description.GroupName
                );
            }
            options.EnableFilter();
            options.EnablePersistAuthorization();
        });
    }
}