namespace Qubi.Api.Config;

public sealed class CorsConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        var cors = builder.Configuration
            .GetRequiredSection("AllowedOrigins")
            .Get<string[]>()
            ?? throw new Exception("AllowedOrigins section is required");
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
                policy.WithOrigins(cors);
            });
        });
    }

    public void Use(WebApplication app)
    {
        app.UseCors();
    }
}