using System.Text.Json.Serialization;

using Qubi.Api.Controllers.Converters;
using Qubi.Api.Controllers.Errors;
namespace Qubi.Api.Config;

public sealed class ControllersConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
                options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
                options.JsonSerializerOptions.Converters.Add(new InstantConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
        
        
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = ValidationError.GenerateBadRequest;
        });
    }

    public void Use(WebApplication app)
    {
        app.MapControllers();
    }
}