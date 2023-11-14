using Webion.Template.Storage.Extensions;
namespace Qubi.Api.Config;

public sealed class StorageConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        var conn = builder.Configuration.GetConnectionString("default");
        
        builder.Services.AddStorage(options =>
        {
            options.UseNpgsql(conn, o =>
            {
                o.UseNodaTime();
            });
        });
    }

    public void Use(WebApplication app)
    {
        throw new NotImplementedException();
    }
}