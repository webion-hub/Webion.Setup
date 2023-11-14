namespace Qubi.Api.Config;


internal sealed class I18NConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization();
    }

    public void Use(WebApplication app)
    {
        var supportedCultures = new[]
        {
            "it",
            "en"
        };

        app.UseRequestLocalization(new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures)
        );
    }
}