using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Qubi.Api.AuthN.Extensions;
using Qubi.Api.Settings;

using Webion.Template.Storage.Data.Identity;
namespace Qubi.Api.Config;

public sealed class AuthConfig : IWebApplicationConfiguration
{
    public void Add(WebApplicationBuilder builder)
    {
        var jwtOptions = builder.Configuration
            .GetSection(JwtSettings.Section)
            .Get<JwtSettings>()!;

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "Webion.Template_authN";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.Domain = builder.Configuration["Cookie:Domain"];
            options.Events.UseStatusCodeHandlers();
        });
        
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudiences = jwtOptions.Audiences,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

        builder.Services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            
            options.AddPolicy("Admin",
                policy => policy.RequireRole(RoleDbo.Admin));
        });
    }

    public void Use(WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}