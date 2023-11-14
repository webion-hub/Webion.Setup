using Webion.Template.Application.Extensions;
namespace Qubi.Api.Config;

public sealed class ApplicationConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IClock>(SystemClock.Instance);
        builder.Services.AddApplication();
    }

    public void Use(WebApplication app)
    {
        throw new NotImplementedException();
    }
}