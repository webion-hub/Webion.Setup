using Serilog;

namespace Qubi.Api.Config;

public sealed class LoggingConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();
    }

    public void Use(WebApplication app)
    {
        throw new NotImplementedException();
    }
}