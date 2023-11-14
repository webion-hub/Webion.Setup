using Microsoft.AspNetCore.Mvc.Versioning;
namespace Qubi.Api.Config;

public sealed class ApiVersioningConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader()
            );
        });
    }

    public void Use(WebApplication app)
    {
    }
}