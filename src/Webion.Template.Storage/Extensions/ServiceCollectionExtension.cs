using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Webion.Template.Storage.Data.Identity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Webion.Template.Storage.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddStorage(this IServiceCollection services,
        Action<DbContextOptionsBuilder> dbOptions
    )
    {
        services
            .AddIdentity<UserDbo, RoleDbo>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<{ProjectName}DbContext>()
            .AddDefaultTokenProviders();

        services.AddHttpContextAccessor();
        services.AddDbContextFactory<{ProjectName}DbContext>(dbOptions, ServiceLifetime.Scoped);
    }
}