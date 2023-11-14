using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Webion.Template.Storage.Data.Identity;

namespace Webion.Template.Storage.Contexts;

public sealed class {ProjectName}DbContext : IdentityDbContext<UserDbo, RoleDbo, Guid>
{
    public {ProjectName}DbContext(DbContextOptions<{ProjectName}DbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof({ProjectName}DbContext).Assembly);
        
        builder.Entity<UserDbo>().ToTable("users", Schemas.Identity);
        builder.Entity<RoleDbo>().ToTable("roles", Schemas.Identity);
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles", Schemas.Identity);
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims", Schemas.Identity);
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins", Schemas.Identity);
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims", Schemas.Identity);
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens", Schemas.Identity);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);
        builder.Properties<Enum>().HaveConversion<string>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        builder.UseSnakeCaseNamingConvention();
    }
}