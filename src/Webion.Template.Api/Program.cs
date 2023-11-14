using Qubi.Api.Config;
using Qubi.Api.Config.Swagger;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Add<ApiVersioningConfig>();
builder.Add<ControllersConfig>();
builder.Add<CorsConfig>();
builder.Add<I18NConfig>();
builder.Add<StorageConfig>();
builder.Add<SwaggerConfig>();
builder.Add<AuthConfig>();
builder.Add<ApplicationConfig>();
builder.Add<LoggingConfig>();

var app = builder.Build();

app.Use<SwaggerConfig>();
app.Use<I18NConfig>();

app.UseHsts();

app.Use<CorsConfig>();
app.Use<AuthConfig>();
app.Use<ControllersConfig>();

try
{
    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}